using MediatR;
using Toy.Domain.Channels;
using Toy.Domain.Notices;

namespace Toy.Application.Services.Notices;

public class AddNoticeCommandHandler : IRequestHandler<AddNoticeCommand, Notice>
{
    private readonly INoticeRepository _noticeRepository;
    private readonly IChannelRepository _channelRepository;

    public AddNoticeCommandHandler(
        INoticeRepository noticeRepository,
        IChannelRepository channelRepository)
    {
        _noticeRepository = noticeRepository;
        _channelRepository = channelRepository;
    }

    public async Task<Notice> Handle(AddNoticeCommand request, CancellationToken cancellationToken)
    {
        // TODO : (dh) Validation command.
        var channels = await _channelRepository.FindAllAsync(channel => request.Channels.Contains(channel.Code));
        var notice = Notice.Create(request.Title, request.Content, channels);

        await _noticeRepository.UnitOfWork.TransactionStartAsync(cancellationToken);

        try
        {
            await _noticeRepository.AddAsync(notice);
            await _noticeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken, (1 + request.Channels.Length));
        }
        catch (Exception)
        {
            await _noticeRepository.UnitOfWork.TransactionRollbackAsync();
            throw;
        }
        
        return notice;
    }
}
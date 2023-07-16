using Toy.Domain.Channels;
using Toy.Domain.Notices;
using Toy.Infrastructure.Contexts;

namespace Toy.Application.Services.Initialize;

public class DataInitializeService
{
    private readonly SolutionContext _solutionContext;

    public DataInitializeService(SolutionContext solutionContext)
    {
        _solutionContext = solutionContext;
    }

    public void Execute()
    {
        var channelCodes = new[]
        {
            ChannelCode.Channel1,
            ChannelCode.Channel2,
            ChannelCode.Channel3,
            ChannelCode.Channel4,
            ChannelCode.Channel5,
            ChannelCode.Channel6,
            ChannelCode.Channel7,
            ChannelCode.Channel8,
        };

        var channels = channelCodes
            .Select(code => new Channel { Code = code })
            .ToList();

        _solutionContext.Channels.AddRange(channels);
        _solutionContext.SaveChanges();

        var notices = new List<Notice>();

        for (int i = 0; i < 10000; i++)
        {
            var notice = new Notice
            {
                Title = $"Notice : {i}",
                Content = $"Content : {i}",
                StartDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };

            notices.Add(notice);
        }

        _solutionContext.Notices.AddRange(notices);
        _solutionContext.SaveChanges();

        var noticeChannels = new List<NoticeChannel>();

        notices.ForEach(notice =>
        {
            channels.ForEach(channel =>
            {
                var noticeChannel = new NoticeChannel()
                {
                    Notice = notice,
                    Channel = channel,
                };

                noticeChannels.Add(noticeChannel);
            });
        });

        _solutionContext.NoticeChannels.AddRange(noticeChannels);
        _solutionContext.SaveChanges();

        var noticeSearches = new List<NoticeSearch>();
        
        notices.ForEach(notice =>
        {
            var noticeSearch = new NoticeSearch()
            {
                Notice = notice,
                IsChannel01 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel1),
                IsChannel02 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel2),
                IsChannel03 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel3),
                IsChannel04 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel4),
                IsChannel05 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel5),
                IsChannel06 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel6),
                IsChannel07 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel7),
                IsChannel08 = noticeChannels.Any(row =>
                    row.Notice.Id == notice.Id && row.Channel.Code == ChannelCode.Channel8),
            };
            
            noticeSearches.Add(noticeSearch);
        });    
        
        _solutionContext.NoticeSearches.AddRange(noticeSearches);
        _solutionContext.SaveChanges();

    }
}
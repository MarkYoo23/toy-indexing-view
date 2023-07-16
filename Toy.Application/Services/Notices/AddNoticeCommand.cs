using MediatR;
using Toy.Domain.Notices;

namespace Toy.Application.Services.Notices;

public class AddNoticeCommand : IRequest<Notice>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string[] Channels { get; set; }
}
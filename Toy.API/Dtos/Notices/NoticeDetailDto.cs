using Toy.Domain.Notices;

namespace Toy.API.Dtos.Notices;

public class NoticeDetailDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string[] Channels { get; set; } = null!;
}
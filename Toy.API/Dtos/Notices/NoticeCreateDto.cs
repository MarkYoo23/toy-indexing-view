namespace Toy.API.Dtos.Notices;

public class NoticeCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Channels { get; set; }
}
namespace Toy.API.Dtos.Notices;

public class NoticeSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string[] Channels { get; set; } = null!;
}
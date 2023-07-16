namespace Toy.Application.Services.Notices;

public class NoticeQueryParameter
{
    public string TitleKeyword { get; set; } = string.Empty;
    public DateTime? StartFromDate { get; set; }
    public DateTime? StartToDate { get; set; }
    public List<string> Channels { get; set; } = new ();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
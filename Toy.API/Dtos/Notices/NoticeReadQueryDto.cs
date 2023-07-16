namespace Toy.API.Dtos.Notices;

public class NoticeReadQueryDto
{
    public string? TitleKeyword { get; set; }
    public string? Channels { get; set; }
    
    public DateTime? StartFromDate { get; set; }
    public DateTime? StartToDate { get; set; }
    
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
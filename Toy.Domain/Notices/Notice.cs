using Toy.Domain.Channels;
using Toy.Domain.SeedWorks;

#pragma warning disable CS8618
namespace Toy.Domain.Notices;

public class Notice : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime StartDate { get; set; }

    public List<Channel> Channels { get; set; } = new();
    public List<NoticeChannel> NoticeChannels { get; set; } = new();
    public NoticeSearch? NoticeSearch { get; set; } = null!;
    
    public static Notice Create(string title, string content, IEnumerable<Channel> channels)
    {
        var notice = new Notice
        {
            Title = title,
            Content = content,
            CreatedDate = DateTime.Now,
            StartDate = DateTime.Now,
        };
        
        notice.Channels.AddRange(channels);
        return notice;
    }
}
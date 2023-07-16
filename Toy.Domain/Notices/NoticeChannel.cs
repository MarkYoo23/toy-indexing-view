using Toy.Domain.Channels;
using Toy.Domain.SeedWorks;

namespace Toy.Domain.Notices;

public class NoticeChannel : Entity
{
    public int NoticeId { get; set; }
    public int ChannelId { get; set; }
    
    public Notice Notice { get; set; } = null!;
    public Channel Channel { get; set; } = null!;
}
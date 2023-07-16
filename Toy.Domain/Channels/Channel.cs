using Toy.Domain.Notices;
using Toy.Domain.SeedWorks;

#pragma warning disable CS8618
namespace Toy.Domain.Channels;

public class Channel : Entity
{
    public string Code { get; set; }

    public List<Notice> Notices { get; set; } = new();
    public List<NoticeChannel> NoticeChannels { get; set; } = new();
}
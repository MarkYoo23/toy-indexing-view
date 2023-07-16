using Toy.Domain.SeedWorks;

namespace Toy.Domain.Notices;

public class NoticeSearch : Entity
{
    public int NoticeId { get; set; }
    public bool IsChannel01 { get; set; }
    public bool IsChannel02 { get; set; }
    public bool IsChannel03 { get; set; }
    public bool IsChannel04 { get; set; }
    public bool IsChannel05 { get; set; }
    public bool IsChannel06 { get; set; }
    public bool IsChannel07 { get; set; }
    public bool IsChannel08 { get; set; }

    public Notice Notice { get; set; } = null!;
}
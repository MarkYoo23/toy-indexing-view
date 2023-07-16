using Toy.API.Dtos.Commons;

namespace Toy.API.Dtos.Notices;

public class NoticeReadCollectionDto
{
    public IEnumerable<NoticeSummaryDto> Notices { get; set; } = null!;
 
    public PaginationReadDto Pagination { get; set; } = null!;
}
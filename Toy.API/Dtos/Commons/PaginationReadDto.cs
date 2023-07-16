namespace Toy.API.Dtos.Commons;

public class PaginationReadDto
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public int TotalRecord { get; set; }

    // TODO : (dh) will be test...
    public static PaginationReadDto Create(
        int page, int pageSize, int totalRecord)
    {
        return new PaginationReadDto()
        {
            Page = page,
            PageSize = pageSize,
            TotalPage = (totalRecord - 1) / pageSize + 1,
            TotalRecord = totalRecord
        };
    }
}
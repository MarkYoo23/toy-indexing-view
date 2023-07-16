using Toy.Domain.Notices;
using Toy.Infrastructure.Contexts;
using Toy.Infrastructure.SeedWorks;

namespace Toy.Infrastructure.Repositories;

public class NoticeRepository : GenericRepository<Notice>, INoticeRepository
{
    private readonly SolutionContext _context;

    // ReSharper disable once SuggestBaseTypeForParameterInConstructor
    public NoticeRepository(SolutionContext context) : base(context)
    {
        _context = context;
    }
}
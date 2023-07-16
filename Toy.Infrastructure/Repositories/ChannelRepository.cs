using Toy.Domain.Channels;
using Toy.Infrastructure.Contexts;
using Toy.Infrastructure.SeedWorks;

namespace Toy.Infrastructure.Repositories;

public class ChannelRepository : GenericRepository<Channel>, IChannelRepository
{
    public ChannelRepository(SolutionContext context) : base(context)
    {
    }
}
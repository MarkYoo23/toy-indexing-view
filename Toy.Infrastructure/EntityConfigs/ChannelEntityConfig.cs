using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toy.Domain.Channels;

namespace Toy.Infrastructure.EntityConfigs;

public class ChannelEntityConfig : TableConfig<Channel>
{
    protected override string TableName => nameof(Channel);

    protected override void ConfigureOthers(EntityTypeBuilder<Channel> builder)
    {
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toy.Domain.Notices;

namespace Toy.Infrastructure.EntityConfigs;

public class NoticeChannelEntityConfig : TableConfig<NoticeChannel>
{
    protected override string TableName => nameof(NoticeChannel);
    
    protected override void ConfigureOthers(EntityTypeBuilder<NoticeChannel> builder)
    {
    }
}
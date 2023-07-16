using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toy.Domain.Notices;

namespace Toy.Infrastructure.EntityConfigs;

public class NoticeSearchEntityConfig : TableConfig<NoticeSearch>
{
    protected override string TableName => nameof(NoticeSearch);
    
    protected override void ConfigureOthers(EntityTypeBuilder<NoticeSearch> builder)
    {
        builder.HasIndex(col => col.IsChannel01);
        builder.HasIndex(col => col.IsChannel02);
        builder.HasIndex(col => col.IsChannel03);
        builder.HasIndex(col => col.IsChannel04);
        builder.HasIndex(col => col.IsChannel05);
        builder.HasIndex(col => col.IsChannel06);
        builder.HasIndex(col => col.IsChannel07);
        builder.HasIndex(col => col.IsChannel08);
    }
}
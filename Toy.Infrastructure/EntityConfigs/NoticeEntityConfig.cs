using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toy.Domain.Notices;

namespace Toy.Infrastructure.EntityConfigs;

public class NoticeEntityConfig : TableConfig<Notice>
{
    protected override string TableName => nameof(Notice);

    protected override void ConfigureOthers(EntityTypeBuilder<Notice> builder)
    {
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toy.Domain.SeedWorks;

namespace Toy.Infrastructure.EntityConfigs;

public abstract class TableConfig<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    protected abstract string TableName { get; }
    
    public void Configure(EntityTypeBuilder<T> builder)
    {
        ConfigureTable(builder);
        ConfigureOthers(builder);
    }

    private void ConfigureTable(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(col => col.Id);
        builder.Property(col => col.Id).ValueGeneratedOnAdd();
    }

    protected abstract void ConfigureOthers(EntityTypeBuilder<T> builder);
}
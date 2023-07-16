using Microsoft.EntityFrameworkCore;
using Toy.Domain.Channels;
using Toy.Domain.Notices;
using Toy.Infrastructure.EntityConfigs;
using Toy.Infrastructure.SeedWorks;

namespace Toy.Infrastructure.Contexts;

public class SolutionContext : BaseContext
{
    public DbSet<Channel> Channels { get; set; } = null!;
    
    public DbSet<Notice> Notices { get; set; } = null!;
    public DbSet<NoticeChannel> NoticeChannels { get; set; } = null!;
    
    public DbSet<NoticeSearch> NoticeSearches { get; set; } = null!;
    
    public SolutionContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChannelEntityConfig());
        
        modelBuilder.ApplyConfiguration(new NoticeEntityConfig());
        modelBuilder.ApplyConfiguration(new NoticeChannelEntityConfig());
        modelBuilder.ApplyConfiguration(new NoticeSearchEntityConfig());
        
        modelBuilder.Entity<Channel>()
            .HasMany(e => e.Notices)
            .WithMany(e => e.Channels)
            .UsingEntity<NoticeChannel>(
                l => l.HasOne<Notice>(e => e.Notice)
                    .WithMany(e => e.NoticeChannels)
                    .HasForeignKey(e => e.NoticeId),
                r => r.HasOne<Channel>(e => e.Channel)
                    .WithMany(e => e.NoticeChannels)
                    .HasForeignKey(e => e.ChannelId)
            );

        modelBuilder.Entity<Notice>()
            .HasOne(e => e.NoticeSearch)
            .WithOne(e => e.Notice)
            .HasForeignKey<NoticeSearch>(e => e.NoticeId)
            .IsRequired();
    }
}
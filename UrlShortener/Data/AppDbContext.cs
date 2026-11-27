using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ShortUrl> ShortUrls => Set<ShortUrl>();

    public DbSet<ClickEvent> ClickEvents => Set<ClickEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShortUrl>(entity =>
        {
            entity.ToTable("ShortUrls");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ShortCode)
                .IsRequired()
                .HasMaxLength(16);

            entity.Property(e => e.OriginalUrl)
                .IsRequired()
                .HasMaxLength(2048);

            entity.Property(e => e.CreatedAt)
                .IsRequired();

            entity.Property(e => e.ExpiresAt)
                .IsRequired(false);

            entity.HasIndex(e => e.ShortCode)
                .IsUnique();

            entity.HasMany(e => e.ClickEvents)
                .WithOne(e => e.ShortUrl)
                .HasForeignKey(e => e.ShortUrlId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ClickEvent>(entity =>
        {
            entity.ToTable("ClickEvents");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ShortUrlId)
                .IsRequired();

            entity.Property(e => e.ClickedAt)
                .IsRequired();

            entity.Property(e => e.IpAddress)
                .IsRequired()
                .HasMaxLength(45);

            entity.Property(e => e.DeviceType)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Browser)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Referer)
                .IsRequired(false)
                .HasMaxLength(2048);

            entity.HasIndex(e => new { e.ShortUrlId, e.ClickedAt });
        });
    }
}


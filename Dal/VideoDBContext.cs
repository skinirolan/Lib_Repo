using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;

namespace Dal;

public class VideoDBContext : DbContext
{
    private string _connectionString;
    public VideoDBContext()
    {
        _connectionString = "Host=localhost;Port=5432;Database=VideoDB;Username=postgres;Password=admin";//несколько раз проверял
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)//пока так
    {

        modelBuilder.Entity<VideoEntity>().HasKey(v => v.Id);

        modelBuilder.Entity<VideoEntity>()
            .Property(v => v.Name)
            .IsRequired();

        modelBuilder.Entity<VideoEntity>()
           .Property(v => v.Description);

        modelBuilder.Entity<VideoEntity>()
           .Property(v => v.Duration);
    }

    public DbSet<VideoEntity> videoEntities { get; set; }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Project_VH.Domain.Entities;

namespace Project_VH.Dal;

/// <summary>
/// Контекст базы данных для работы с видео
/// </summary>
public class VideoDBContext : DbContext
{
    /// <summary>
    /// Конфигурация
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Конструктор контекста
    /// </summary>
    public VideoDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    /// <summary>
    /// Конфигурация контекста
    /// </summary>
    /// <param name="optionsBuilder"><see cref="DbContextOptionsBuilder"/></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine("Строка такая: "+connectionString);
        optionsBuilder.UseNpgsql(connectionString);
    }
    
    /// <summary>
    /// Конфигурация модели видео
    /// </summary>
    /// <param name="modelBuilder"><see cref="ModelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Video>().HasKey(v => v.Id);

        modelBuilder.Entity<Video>()
            .Property(v => v.Name)
            .IsRequired();

        modelBuilder.Entity<Video>()
           .Property(v => v.Description);

        modelBuilder.Entity<Video>()
           .Property(v => v.Duration);
    }

    /// <summary>
    /// DBSet с роликами
    /// </summary>
    public DbSet<Video> Videos => Set<Video>();

}
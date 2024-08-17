using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Project_VH.Domain.Entities;

namespace Project_VH.Dal.DBContext;

/// <summary>
/// контекст базы данных для работы с видео
/// </summary>
public class VideoDBContext : DbContext
{
    /// <summary>
    /// string, содержащий информаицию о подключении к бд
    /// </summary>
    private string _connectionString;

    /// <summary>
    /// Конструктор контекста
    /// </summary>
    public VideoDBContext() : base()
    {
        _connectionString = "Host=localhost;Port=5432;Database=VideoDB;Username=postgres;Password=admin";//подключение пока остается тут, позже перенесу куда полагается
        Database.EnsureCreated();
    }

    /// <summary>
    /// Конфигурация контекста
    /// </summary>
    /// <param name="optionsBuilder"><see cref="DbContextOptionsBuilder"/></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    /// <summary>
    /// Конфигурация модели видео
    /// </summary>
    /// <param name="modelBuilder"><see cref="ModelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)//пока так. Будет больше моделей - буду менять (такого не будет)
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

    /// <summary>
    /// DBSet с роликами
    /// </summary>
    public DbSet<VideoEntity> VideoEntities { get; set; }
}
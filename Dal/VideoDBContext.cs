using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dal;

public class VideoDBContext : DbContext
{
    private string _connectionString;
    public VideoDBContext()
    {
        _connectionString = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=VideoDB";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
    public DbSet<VideoEntity> videoEntities { get; set; }
}
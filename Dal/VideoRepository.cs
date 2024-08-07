
using Microsoft.EntityFrameworkCore;

namespace Dal;


/// <summary>
/// Пока ни где не используется. Когда роазберусь с бд, переделаю все под репос
/// </summary>
public class VideoRepository
{
    private VideoDBContext _dbContext;

    public VideoRepository(VideoDBContext dbcontext)
    {
        _dbContext = dbcontext;
    }

    public async Task<List<VideoEntity>> GetAll()
    {
        return _dbContext.VideoEntities
            .AsNoTracking()
            .ToList();
    }

    public async Task Add(Guid id, string name, string description, TimeSpan duration)
    {
        
        var videoEntity = new VideoEntity
        {
            Id = id,
            Name = name,
            Description = description,
            Duration = duration
        };
        await _dbContext.AddAsync(videoEntity);
        await _dbContext.SaveChangesAsync();
    }


}

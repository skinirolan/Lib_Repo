using Dal.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Domain.Repositories;
using Domain.Entities;

namespace Dal.Repositories;

//<inheritdoc/>
public class VideoRepository:IVideoRepository
{
    private VideoDBContext _dbContext;

    //<inheritdoc/>
    public VideoRepository(VideoDBContext dbcontext)
    {
        _dbContext = dbcontext;
    }

    //<inheritdoc/>
    public List<VideoEntity> GetAll()
    {
        return _dbContext.VideoEntities
            .AsNoTracking()
            .ToList();
    }

    //<inheritdoc/>
    public async Task Add(VideoEntity videoEntity)
    {

        await _dbContext.AddAsync(videoEntity);
        await _dbContext.SaveChangesAsync();
    }

    //<inheritdoc/>
    public async Task Update(VideoEntity videoEntity)
    {
        var video = _dbContext.VideoEntities.FirstOrDefault(x => x.Id == videoEntity.Id);
        if (video != null)
        {
            video.Duration = videoEntity.Duration;
            video.Name = videoEntity.Name;
            video.Description = videoEntity.Description;
            await _dbContext.SaveChangesAsync();
        }
        else throw new NullReferenceException("Обьект не найден");
    }

    //<inheritdoc/>
    public void Delete(Guid id)
    {

       var video = _dbContext.VideoEntities.FirstOrDefault(x=>x.Id==id);
        if (video!=null)
        {
            _dbContext.VideoEntities.Remove(video);
            _dbContext.SaveChanges();
        }
        else
        {
            throw new NullReferenceException("Обьекта не найден");
        }
    }

    //<inheritdoc/>
    public  VideoEntity GetById(Guid id)
    {
         var videoEntity=_dbContext.VideoEntities.FirstOrDefault(x => x.Id == id);
        if (videoEntity != null)
        {
            return videoEntity;
        }
        else
        {
            throw new NullReferenceException("Обьект не найден");
        }
    }

    

}

using Project_VH.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Project_VH.Domain.Repositories;
using Project_VH.Domain.Entities;

namespace Project_VH.Dal.Repositories;

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
    public List<Video> GetAll()
    {
        return _dbContext.Videos
            .AsNoTracking()
            .ToList();
    }

    //<inheritdoc/>
    public async Task Add(Video videoEntity)
    {

        await _dbContext.AddAsync(videoEntity);
        await _dbContext.SaveChangesAsync();
    }

    //<inheritdoc/>
    public async Task Update(Video videoEntity)
    {
        var video = _dbContext.Videos.FirstOrDefault(x => x.Id == videoEntity.Id);
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
    public async Task Delete(Guid id)
    {

       var video = _dbContext.Videos.FirstOrDefault(x=>x.Id==id);
        if (video!=null)
        {
           _dbContext.Remove(video);
           await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new NullReferenceException("Обьекта не найден");
        }
    }

    //<inheritdoc/>
    public  Video GetById(Guid id)
    {
         var videoEntity=_dbContext.Videos.FirstOrDefault(x => x.Id == id);
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

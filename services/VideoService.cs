using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;

namespace Library_bvd53jkl.Services;

public class VideoService:IVideoService
{
    /// <summary>
    /// Логгер
    /// </summary>
    private readonly ILogger<VideoService> _logger;

    /// <summary>
    /// Список роликов
    /// </summary>
    private List<Video> _videos;

    /// <summary>
    /// консткруктор сервиса
    /// </summary>
    public VideoService(ILogger<VideoService> logger) 
    {
        _logger = logger;
        _videos = [];
    }

    //<inheritdoc/> 
    public List<Video> GetFullVideoList()
    {
        if (_videos.Count != 0) return _videos;
        else 
        { 
            _logger.LogError("The video list is empty");
            throw new NullReferenceException("The video list is empty");
        }
    }

    //<inheritdoc/> 
    public Video Get(Guid id)
    {
        var video = _videos.FirstOrDefault<Video>(video => video.Id == id);
        if (video != null)
        {
            return video;
        }
        else
        {
            _logger.LogError("Video with current id doesn't exist");
            throw new NullReferenceException("Video with current id doesn't exist");
        }
    }

    //<inheritdoc/> 
    public Guid Add(Video video)
    {
        _videos.Add(video);
        return video.Id;
    }

    //<inheritdoc/> 
    public void Delete(Guid id) 
    {
        var video = Get(id);
        if (video != null)
        {
            _videos.Remove(video);
        }
        else
        {
            _logger.LogError("The video list is empty");
            throw new NullReferenceException("Video with current id doesn't exist");
        }
    }

    //<inheritdoc/> 
    public void Update (Guid id,VideoInput videoinput)
    {
        var origin=Get(id);
        if (origin != null)
        {
            origin.Name = videoinput.Name;
            origin.Description = videoinput.Description;
            origin.Duration = videoinput.Duration;
        }
        else
        {
            _logger.LogError("Video with current id doesn't exist");
            throw new NullReferenceException("Video with current id doesn't exist");
        }
    }
    //<inheritdoc/>
    public void UpdateDescription(Guid id, string description)
    {
        var origin = Get(id);
        if (origin != null)
        {
            origin.Description = description;
        }
        else
        {
            _logger.LogError("Video with current id doesn't exist");
            throw new NullReferenceException("Video with current id doesn't exist");
        }
    }

    //<inheritdoc/> 
    public void Clear()=> _videos.Clear();
}

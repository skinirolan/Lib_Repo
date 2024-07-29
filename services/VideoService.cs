using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;

namespace Library_bvd53jkl.Services;

public class VideoService:IVideoService
{
    /// <summary>
    /// значение, изходя из которого будет формироваться id отдтедльного ролика
    /// </summary>
    private int _idformer;


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
        _idformer = 0;
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
    public Video Get(int id)
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
    public int Add(Video video)
    {
        _idformer++;
        video.Id = _idformer;
        _videos.Add(video);
        return video.Id;
    }

    //<inheritdoc/> 
    public void Delete(int id) 
    {
        var vid = Get(id);
        if (vid != null)
        {
            _videos.Remove(vid);
        }
        else
        {
            _logger.LogError("The video list is empty");
            throw new NullReferenceException("Video with current id doesn't exist");
        }
    }

    //<inheritdoc/> 
    public void Update (Video video)
    {
        var origin=Get(video.Id);
        if (origin != null)
        {
            origin.Name = video.Name;
            origin.Description = video.Description;
            origin.Duration = video.Duration;
        }
        else
        {
            _logger.LogError("The video list is empty");
            throw new NullReferenceException("Video with current id doesn't exist");
        }
    }

    //<inheritdoc/> 
    public void Clear()
    {
        _videos.Clear();
        _idformer = 0;
    }

    

}

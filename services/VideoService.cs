using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;

namespace Library_bvd53jkl.Services;

public class VideoService:IVideoService
{
    /// <summary>
    /// значение, изходя из которого будет формироваться id отдтедльного ролика
    /// </summary>
    private int _index;

    /// <summary>
    /// Список роликов
    /// </summary>
    private List<Video> _videos;

    /// <summary>
    /// консткруктор сервиса
    /// </summary>
    public VideoService() 
    {
        _index = 0;
        _videos = new List<Video>();
    }

    //<inheritdoc/> 
    public List<Video> GetFullVideoList()
    {
        if (_videos.Count != 0) return _videos;
        else throw new NullReferenceException("The video list is empty");
    }

    //<inheritdoc/> 
    public Video Get(int id)
    {
        var vid = _videos.FirstOrDefault<Video>(vid => vid.Id == id);
        if (vid != null)
        {
            return vid;
        }
        else throw new NullReferenceException("Video with current id doesn't exist");

    }
    //<inheritdoc/> 
    public void Add(Video video)
    {
        _index++;
        video.Id = _index;
        _videos.Add(video);
    }

    //<inheritdoc/> 
    public void Delete(int id) 
    {
        var vid=Get(id);
        if (vid != null)
        {
            _videos.Remove(vid);
        }
        else throw new NullReferenceException("Video with current id doesn't exist");
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
        else throw new NullReferenceException("Video with current id doesn't exist");
    }

    //<inheritdoc/> 
    public void Clear()
    {
        _videos.Clear();
        _index = 0;
    }

    

}

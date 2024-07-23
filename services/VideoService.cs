using Library_bvd53jkl.models;

namespace Library_bvd53jkl.services
{
    public class VideoService
    {
        
        public VideoService() 
        {
            _index = 0;
            _videos = new List<Video>();
        }  
        
        /// <summary>
        /// 
        /// </summary>
        private int _index;
        private List<Video> _videos;
        
        public List<Video> GetFullVideoList()
        {
            return _videos;
        }

        
        public Video Get(int id)
        {
            return _videos.FirstOrDefault<Video>(vid=>vid.Id==id);
        }
        public void add(Video video)
        {
            _index++;
            _videos.Add(video);
        }
        public void delete(int id) 
        {
            var vid=Get(id);
            if (vid!=null)
            {
                _videos.Remove(vid);
            }
        }
        public void update (Video video)
        {
            var origin=Get(video.Id);
            if (origin!=null)
            {
                origin.Name = video.Name;
                origin.Description = video.Description;
                origin.Duration = video.Duration;
            }



        }

        

    }
}

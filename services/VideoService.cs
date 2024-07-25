using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;

namespace Library_bvd53jkl.Services
{
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
        
        /// <summary>
        /// Получение всех роликов
        /// </summary>
        /// <returns>List со всеми имеющимеся видеороликами</returns>
        public List<Video> getFullVideoList()
        {
            if (_videos.Count!=0) return _videos;
            else throw new NullReferenceException("The video list is empty");
        }

        /// <summary>
        /// Получение ролика по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>видеоролик с соответствующим id</returns>
        public Video get(int id)
        {
            var vid = _videos.FirstOrDefault<Video>(vid => vid.Id == id);
            if (vid != null)
            {
                return vid;
            }
            else throw new NullReferenceException("Video with current id doesn't exist");

        }
        /// <summary>
        /// Добавление ивидеоролика в List
        /// </summary>
        /// <param name="video"></param>
        public void add(Video video)
        {
            _index++;
            video.Id = _index;
            _videos.Add(video);
        }

        /// <summary>
        /// Удаление ролика из листа
        /// </summary>
        /// <param name="id"></param>
        public void delete(int id) 
        {
            var vid=get(id);
            if (vid != null)
            {
                _videos.Remove(vid);
            }
            else throw new NullReferenceException("Video with current id doesn't exist");
        }

        /// <summary>
        /// Изменение информации о ролике
        /// </summary>
        /// <param name="video"></param>
        public void update (Video video)
        {
            var origin=get(video.Id);
            if (origin != null)
            {
                origin.Name = video.Name;
                origin.Description = video.Description;
                origin.Duration = video.Duration;
            }
            else throw new NullReferenceException("Video with current id doesn't exist");
        }
        
        /// <summary>
        /// Полная очистка списка
        /// </summary>
        public void clear()
        {
            _videos.Clear();
            _index = 0;
        }

        

    }
}

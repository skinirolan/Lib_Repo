using Library_bvd53jkl.Models;
using Library_bvd53jkl.services;

namespace Library_bvd53jkl.Services
{
    public class VideoService:IVideoService
    {
        /// <summary>
        /// консткруктор сервиса
        /// </summary>
        public VideoService() 
        {
            _index = 0;
            _videos = new List<Video>();
        }  
        
        /// <summary>
        /// значение, изходя из которого будет формироваться id отдтедльного ролика
        /// </summary>
        private int _index;

        /// <summary>
        /// Список роликов
        /// </summary>
        private List<Video> _videos;
        
        /// <summary>
        /// Получение всех роликов
        /// </summary>
        /// <returns>List со всеми имеющимеся видеороликами</returns>
        public List<Video> GetFullVideoList()
        {
            return _videos;
        }

        /// <summary>
        /// Получение ролика по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>видеоролик с соответствующим id</returns>
        public Video get(int id)
        {
            return _videos.FirstOrDefault<Video>(vid=>vid.Id==id);
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
            else throw new Exception("Video with current id doesn't exist");
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
            else throw new Exception("Video with current id doesn't exist");
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

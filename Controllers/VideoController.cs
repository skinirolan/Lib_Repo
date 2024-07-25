using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace Library_bvd53jkl.Controllers
{

    [ApiController]
    [Route("api/videos")]
    public class VideoController : ControllerBase {
        public IVideoService _videoService;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="videoservice"></param>
        public VideoController(IVideoService videoservice)
        {
            _videoService = videoservice;
        }

        /// <summary>
        /// Позволяет получить все сохраненные ролики
        /// </summary>
        /// <returns>list со всеми Video</returns>
        [HttpGet]
        public ActionResult<List<Video>> getAllVideos()
        {
            try
            {
                return _videoService.getFullVideoList();
            }catch (NullReferenceException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Позволяет получить видео по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Один конкретный Video по выбранному id</returns>
        [HttpGet("{id}")]
        public ActionResult<Video> getVideoById(int id)
        {
            try
            {
                return _videoService.get(id);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Позволяет добавить ролик в память
        /// </summary>
        /// <param name="video"></param>
        /// <returns>Код результата</returns>
        [HttpPost]
        public ActionResult<Video> postVideo(Video video)
        {
            _videoService.add(video);
            return Created();
        }

        /// <summary>
        /// позволяет удалить ролик из памяти
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Код результата</returns>
        [HttpDelete("{id}")]
        public ActionResult deleteFromList(int id)
        {
            try
            {
                _videoService.delete(id);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Удаление всех данных из списка
        /// </summary>
        /// <returns>код результата</returns>
        [HttpDelete()] 
        public ActionResult nullList() 
        { 
            _videoService.clear();
            return Ok();
        }

        /// <summary>
        /// Позволяет обновить информацию о ролике. Меняется тот ролик, id которого был указан в запросе. Непосредсвтенно id поменять нельзя
        /// </summary>
        /// <param name="video"></param>
        /// <returns>Код результата</returns>
        [HttpPut]
        public ActionResult update(Video video)
        {
            try
            {
                _videoService.update(video);
                return Ok();
            }
            catch (NullReferenceException ex) 
            { 
                return NotFound(ex.Message);
            }
        }
    
    }
}

using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace Library_bvd53jkl.Controllers;


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
    public ActionResult<List<Video>> GetAllVideos()
    {
        try
        {
            return _videoService.GetFullVideoList();
        }
        catch (NullReferenceException ex) 
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Позволяет получить видео по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Один конкретный Video по выбранному id</returns>
    [HttpGet("{id}")]
    public ActionResult<Video> GetVideoById(int id)
    {
        try
        {
            return _videoService.Get(id);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
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
        try
        {
            _videoService.Add(video);
            return Created();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// позволяет удалить ролик из памяти
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Код результата</returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteFromList(int id)
    {
        try
        {
            _videoService.Delete(id);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Удаление всех данных из списка
    /// </summary>
    /// <returns>код результата</returns>
    [HttpDelete()] 
    public ActionResult NullList()
    {
        try
        {
            _videoService.Clear();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Позволяет обновить информацию о ролике. Меняется тот ролик, id которого был указан в запросе. Непосредсвтенно id поменять нельзя
    /// </summary>
    /// <param name="video"></param>
    /// <returns>Код результата</returns>
    [HttpPut]
    public ActionResult Update(Video video)
    {
        try
        {
            _videoService.Update(video);
            return Ok();
        }
        catch (NullReferenceException ex) 
        { 
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

}

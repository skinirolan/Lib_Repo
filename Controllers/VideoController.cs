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
    /// <param name="videoservice">Видеосервис</param>
    public VideoController(IVideoService videoservice)
    {
        _videoService = videoservice;
    }

    /// <summary>
    /// Позволяет получить все сохраненные ролики
    /// </summary>
    /// <returns>list со всеми Video</returns>
    [HttpGet]
    public IResult GetAllVideos()
    {
        try
        {
            return TypedResults.Ok(_videoService.GetFullVideoList());
        }
        catch (NullReferenceException ex) 
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Позволяет получить видео по его id
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Один конкретный Video по выбранному id</returns>
    [HttpGet("{id}")]
    public IResult GetVideoById(Guid id)
    {
        try
        {
            return TypedResults.Ok(_videoService.Get(id));
        }
        catch (NullReferenceException ex)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Позволяет добавить ролик в память
    /// </summary>
    /// <param name="videoinput">ролик</param>
    /// <returns>id созданного видео</returns>
    [HttpPost]
    public IResult AddVideo(VideoInput videoinput)
    {
        try
        {
            return TypedResults.Ok(_videoService.Add(new Video(videoinput.Name, videoinput.Description, videoinput.Duration)));
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// позволяет удалить ролик из памяти
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Код результата</returns>
    [HttpDelete("{id}")]
    public IResult DeleteFromList(Guid id)
    {
        try
        {
            _videoService.Delete(id);
            return TypedResults.Ok();
        }
        catch (NullReferenceException ex)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Удаление всех данных из списка
    /// </summary>
    /// <returns>код результата</returns>
    [HttpDelete()] 
    public IResult NullList()
    {
        try
        {
            _videoService.Clear();
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
               statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Позволяет обновить информацию о ролике. Меняется тот ролик, id которого был указан в запросе. Непосредсвтенно id поменять нельзя
    /// </summary>
    /// <param name="videoinput">Ролик вместе с его ID</param>
    /// <returns>Код результата</returns>
    [HttpPut("{id}")]
    public IResult Update(Guid id,VideoInput videoinput)
    {
        try
        {
            _videoService.Update(id,videoinput);
            return TypedResults.Ok();
        }
        catch (NullReferenceException ex)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Позволяет изменить описание выбранного ролика
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <param name="description">Новое описание ролика</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IResult UpdateDescription(Guid id, string description)
    {
        try
        {
            _videoService.UpdateDescription(id, description);
            return TypedResults.Ok();
        }
        catch (NullReferenceException ex)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception ex)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

}

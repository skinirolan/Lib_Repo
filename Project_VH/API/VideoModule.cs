using Carter;
using Carter.OpenApi;
using Project_VH.Domain.Entities;
using Project_VH.Domain.Repositories;
using Project_VH.Contract;

namespace Project_VH.API;

public class VideoModule : ICarterModule
{
    
    /// <inheritdoc/>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("video").IncludeInOpenApi().WithOpenApi(op =>
        {
            op.Tags = [new() { Name = "Video", Description = "Запросы к модулю видео." }];
            return op;
        });

        group.MapGet(string.Empty, GetAllFromDB)
            .WithOpenApi(op =>
            {
                op.Description = "Возвращает список всех видеороликов из базы данных";
                op.Summary = "Возвращает список всех видеороликов из базы данных";
                op.Responses["200"].Description = "Видео успешно получено";
                op.Responses.Add("404", new() { Description = "Видео не найдено" });
                op.Responses.Add("500", new() { Description = "Неизвестная ошибка" });
                return op;
            });

        group.MapPost(string.Empty, AddVideoToDB)
            .WithOpenApi(op =>
            {
                op.Description = "Добавляет видео в базу данных";
                op.Summary = "Добавляет видео в базу данных";
                op.Responses["200"].Description = "Видео успешно получено";
                op.Responses.Add("404", new() { Description = "Видео не найдено" });
                op.Responses.Add("500", new() { Description = "Видео получить не удалось" });
                return op;
            });
       
        group.MapGet("{id}", GetVideoFromDB)
            .WithOpenApi(op =>
            {
                op.Description = "Возвращает видео с соотвтетсвующим id из базы данных";
                op.Summary = "Возвращает видео с соотвтетсвующим id из базы данных";
                op.Responses["200"].Description = "Видео успешно создать.";
                op.Responses.Add("500", new() { Description = "Видео создать не удалось" });
                return op;
            });

        group.MapPut("{id}", UpdateVideoAtDB)
            .WithOpenApi(op =>
            {
                op.Description = "Обновляет видео в базе данных";
                op.Summary = "Обновляет видео в базе данных";
                op.Responses["200"].Description = "Видео успешно обновлено";
                op.Responses.Add("404", new() { Description = "Видео не найдено" });
                op.Responses.Add("500", new() { Description = "Видео получить не удалось" });
                return op;
            });

        group.MapDelete("{id}", DeleteVideoFromDB)
            .WithOpenApi(op =>
            {
                op.Description = "Удаляет видео с выбранным id в базе данных";
                op.Summary = "Удаляет видео с выбранным id в базе данных";
                op.Responses["200"].Description = "Видео успешно удалено";
                op.Responses.Add("404", new() { Description = "Видео не найдено" });
                op.Responses.Add("500", new() { Description = "Видео удалить не удалось" });
                return op;
            });
    }

    /// <summary>
    /// Добавляет видео в бд
    /// </summary>
    /// <param name="videoinput">входные параметры ролика</param>
    /// <returns>ID нового ролика</returns>
    private IResult AddVideoToDB(IVideoRepository videoRepository, VideoInput videoinput)
    {
        try
        {
            var id = Guid.NewGuid();
            videoRepository.Add(new VideoEntity
            {
                Id = id,
                Name = videoinput.Name,
                Description = videoinput.Description,
                Duration = videoinput.Duration
            });
            
            return TypedResults.Ok(id);
        }
        catch (Exception)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }       
    }

    /// <summary>
    /// Возвращает втдео из БД по ID
    /// </summary>
    /// <param name="videoRepository">репозиторий</param>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Ролик с заданным ID</returns>
    private IResult GetVideoFromDB(IVideoRepository videoRepository, Guid id)
    {
        try
        {
            var repVideo = videoRepository.GetById(id);
            var videoOutput = new VideoOutput(repVideo.Id,repVideo.Name,repVideo.Description, repVideo.Duration);
            return TypedResults.Ok(videoOutput);
        }
        catch (NullReferenceException)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Обновляет видеоролик с выбранным ID 
    /// </summary>
    /// <param name="videoRepository">репозиторий</param>
    /// <param name="id">Уникальынй идентификатор</param>
    /// <param name="videoinput">Новые данные ролика</param>
    /// <returns>Код выполнения</returns>
    private IResult UpdateVideoAtDB(IVideoRepository videoRepository, Guid id, VideoInput videoinput)
    {
        try
        {
            videoRepository.Update(new VideoEntity
            {
                Id = id,
                Name = videoinput.Name,
                Description = videoinput.Description,
                Duration = videoinput.Duration
            });
            return TypedResults.Ok();
        }
        catch (NullReferenceException)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Возвращает список всех видеороликов
    /// </summary>
    /// <param name="videoRepository">репозиторий</param>
    /// <returns>List со всеми видеороликами</returns>
    private IResult GetAllFromDB(IVideoRepository videoRepository)
    {
        try
        {
            var videoList=videoRepository.GetAll();
            return TypedResults.Ok(videoList);
        }
        catch (Exception)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Удаляет видео из БД
    /// </summary>
    /// <param name="videoRepository">репозиторий</param>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Код выполнения</returns>
    private IResult DeleteVideoFromDB(IVideoRepository videoRepository, Guid id)
    {
        try
        {
            videoRepository.Delete(id);
            return TypedResults.Ok();
        }
        catch (NullReferenceException)
        {
            return TypedResults.NotFound("Сущность не найдена");
        }
        catch (Exception)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
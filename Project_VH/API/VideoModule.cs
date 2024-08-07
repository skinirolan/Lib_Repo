using Carter;
using Carter.OpenApi;
using Project_VH.Models;
using Project_VH.Services;
using Microsoft.AspNetCore.Mvc;
using Dal;

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

        //group.MapGet(string.Empty, (IVideoService videoService)
        //    => videoService.GetFullVideoList()) 
        //    .WithOpenApi(op =>
        //    {
        //        op.Description = "Возвращает список всех видео.";
        //        op.Summary = "Возвращает список всех видео.";
        //        op.Responses["200"].Description = "Видео успешно получено.";
        //        op.Responses.Add("500", new() { Description = "Видео получить не удалось." });
        //        return op;
        //    });


        group.MapPost("BALLS", AddVideoToDB);

        group.MapGet("{id}", GetVideo)
            .WithOpenApi(op =>
            {
                op.Description = "Возвращает видео по id";
                op.Summary = "Возвращает видео по id";
                op.Responses["200"].Description = "Видео успешно получено.";
                op.Responses.Add("404", new() { Description = "Видео не найдено." });
                op.Responses.Add("500", new() { Description = "Видео создать не удалось." });
                return op;
            });

        group.MapPost(string.Empty, AddVideo)
            .WithOpenApi(op =>
            {
                op.Description = "Добавляет видео в список.";
                op.Summary = "Добавляет видео в список.";
                op.Responses["200"].Description = "Видео успешно создано.";
                op.Responses.Add("500", new() { Description = "Видео создать не удалось." });
                return op;
            });

        group.MapPut("{id}", UpdateVideo)
            .WithOpenApi(op =>
            {
                op.Description = "Обнволяет данные о видео.";
                op.Summary = "Обнволяет данные о видео.";
                op.Responses["200"].Description = "Видео успешно обновлено.";
                op.Responses.Add("404", new() { Description = "Видео не найдено." });
                op.Responses.Add("500", new() { Description = "Видео обновить не удалось." });
                op.Parameters[0].Description = "Id видео.";
                return op;
            });

        group.MapPatch("{id}", UpdateVideoDecription)
            .WithOpenApi(op =>
            {
                op.Description = "Обнволяетописание видео.";
                op.Summary = "Обнволяет описание видео.";
                op.Responses["200"].Description = "Видео успешно обновлено.";
                op.Responses.Add("404", new() { Description = "Видео не найдено." });
                op.Responses.Add("500", new() { Description = "Видео обновить не удалось." });
                return op;
            });

        group.MapDelete("{id}", DeleteVideo)
            .WithOpenApi(op =>
            {
                op.Description = "Удаляет видео из списка";
                op.Summary = "Удаляет видео из списка";
                op.Responses["200"].Description = "Видео успешно уддалено.";
                op.Responses.Add("404", new() { Description = "Видео не найдено." });
                op.Responses.Add("500", new() { Description = "Видео удалить не удалось." });
                return op;
            });
    }

    /// <summary>
    /// Обновляет все данные видеоролика
    /// </summary>
    /// <param name="videoService">Видеосервис</param>
    /// <param name="id">Уникальный идентфиикатор</param>
    /// <param name="videoInput">Данные видеоролика</param>
    /// <returns></returns>
    private IResult UpdateVideo(IVideoService videoService,
                                Guid id,
                                VideoInput videoInput)
    {
        try
        {
            videoService.Update(id, videoInput);
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
    /// Получение видео
    /// </summary>
    /// <param name="videoService"></param>
    /// <param name="id"></param>
    /// <returns>Выбранный видеоролик</returns>
    private IResult GetVideo(IVideoService videoService, Guid id)
    {
        try
        {
            return TypedResults.Ok(videoService.Get(id));

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
    /// Добавляет ролик
    /// </summary>
    /// <param name="videoService">Видеосервис</param>
    /// <param name="videoInput">Данные видеоролика</param>
    /// <returns>Статус-код</returns>
    private IResult AddVideo(IVideoService videoService,
                            VideoInput videoInput)
    {
        try
        {
            return TypedResults.Json(videoService.Add(
                new Video(videoInput.Name,
                videoInput.Description,
                videoInput.Duration)),
                statusCode: StatusCodes.Status201Created);
        }
        catch (Exception)
        {
            return TypedResults.Json("Произошла неизвестная ошибка",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Обновляет описание выбранного видеоролика
    /// </summary>
    /// <param name="videoService">Видеосервис</param>
    /// <param name="id">Уникальный идентфиикатор</param>
    /// <param name="description">Новый текст описания ролика</param>
    /// <returns>Статус-код</returns>
    private IResult UpdateVideoDecription(IVideoService videoService, Guid id, string description)
    {
        try
        {
            videoService.Get(id).Description = description;
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
    /// Удаление видео
    /// </summary>
    /// <param name="videoService">Видеосервис</param>
    /// <param name="id">Уникальный идентфиикатор</param>
    /// <returns>Статус-код</returns>
    private IResult DeleteVideo(IVideoService videoService, Guid id)
    {
        try
        {
            videoService.Delete(id);
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
    /// Добавляет видео в бд
    /// </summary>
    /// <param name="videoinput">входные параметры</param>
    /// <returns>пока нихуя</returns>
    private IResult AddVideoToDB(VideoInput videoinput)
    {

        VideoEntity videoEntity = new VideoEntity
        {
            Name = videoinput.Name,
            Description = videoinput.Description,
            Duration = videoinput.Duration,
            Id = Guid.NewGuid()
        };

        //пока просто хочу пока что добавить данные хоть как-то, репозиторий добавлю, когда все я разберусь
        
        var dbcontext = new VideoDBContext();
        dbcontext.Database.EnsureCreated(); // короче это наш бро на все времена, держим в голове
        dbcontext.VideoEntities.Add(videoEntity);
        dbcontext.SaveChanges();
        return TypedResults.Ok(videoEntity.Id);
    }
      
}
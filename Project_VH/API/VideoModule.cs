﻿using Carter;
using Carter.OpenApi;
using Project_VH.Models;
using Project_VH.Services;
using Microsoft.AspNetCore.Mvc;
using Dal.DBContext;
using Dal.Repositories;

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

        //group.MapGet("{id}", GetVideo)
        //    .WithOpenApi(op =>
        //    {
        //        op.Description = "Возвращает видео по id";
        //        op.Summary = "Возвращает видео по id";
        //        op.Responses["200"].Description = "Видео успешно получено.";
        //        op.Responses.Add("404", new() { Description = "Видео не найдено." });
        //        op.Responses.Add("500", new() { Description = "Видео создать не удалось." });
        //        return op;
        //    });

        //group.MapPost(string.Empty, AddVideo)
        //    .WithOpenApi(op =>
        //    {
        //        op.Description = "Добавляет видео в список.";
        //        op.Summary = "Добавляет видео в список.";
        //        op.Responses["200"].Description = "Видео успешно создано.";
        //        op.Responses.Add("500", new() { Description = "Видео создать не удалось." });
        //        return op;
        //    });

        //group.MapPut("{id}", UpdateVideo)
        //    .WithOpenApi(op =>
        //    {
        //        op.Description = "Обнволяет данные о видео.";
        //        op.Summary = "Обнволяет данные о видео.";
        //        op.Responses["200"].Description = "Видео успешно обновлено.";
        //        op.Responses.Add("404", new() { Description = "Видео не найдено." });
        //        op.Responses.Add("500", new() { Description = "Видео обновить не удалось." });
        //        op.Parameters[0].Description = "Id видео.";
        //        return op;
        //    });

        //group.MapPatch("{id}", UpdateVideoDecription)
        //    .WithOpenApi(op =>
        //    {
        //        op.Description = "Обнволяетописание видео.";
        //        op.Summary = "Обнволяет описание видео.";
        //        op.Responses["200"].Description = "Видео успешно обновлено.";
        //        op.Responses.Add("404", new() { Description = "Видео не найдено." });
        //        op.Responses.Add("500", new() { Description = "Видео обновить не удалось." });
        //        return op;
        //    });

        //group.MapDelete("{id}", DeleteVideo)
        //    .WithOpenApi(op =>
        //    {
        //        op.Description = "Удаляет видео из списка";
        //        op.Summary = "Удаляет видео из списка";
        //        op.Responses["200"].Description = "Видео успешно уддалено.";
        //        op.Responses.Add("404", new() { Description = "Видео не найдено." });
        //        op.Responses.Add("500", new() { Description = "Видео удалить не удалось." });
        //        return op;
        //    });
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
            var video = videoRepository.GetById(id);
            return TypedResults.Ok(video);
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
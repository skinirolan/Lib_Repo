using Carter;
using Carter.OpenApi;
using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_bvd53jkl.API;

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

		group.MapGet(string.Empty, (IVideoService videoService) 
			=> videoService.GetFullVideoList())
			.WithOpenApi(op =>
			{
				op.Description = "Возвращает список всех видео.";
				op.Summary = "Возвращает список всех видео.";
				op.Responses["200"].Description = "Видео успешно получено.";
				op.Responses.Add("500", new() { Description = "Видео получить не удалось." });
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
	}

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
}

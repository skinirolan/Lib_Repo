using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Dal.DBContext;
using Dal.Repositories;
using Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddCarter();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("00:00:00")
    });
});

builder.Services.AddDbContext<VideoDBContext>();

builder.Services.AddScoped<IVideoRepository, VideoRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapGroup("v1/api")
    .MapCarter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();

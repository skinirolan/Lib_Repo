using System.ComponentModel.DataAnnotations;

namespace Project_VH.Domain.Entities;

/// <summary>
/// Сущность для базы данных
/// </summary>
public class Video
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }

}

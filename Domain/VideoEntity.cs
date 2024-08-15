using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Сущность для базы данных
/// </summary>
public class VideoEntity
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    public string Description { get; set; }
    [Required] public TimeSpan Duration { get; set; }

}

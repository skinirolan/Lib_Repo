namespace Project_VH.Models;

public class Video
{
    /// <summary>
    /// Конструктор модели
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="description">Описание</param>
    /// <param name="duration">Длительность ролика</param>
    public Video(string name, string description, TimeSpan duration)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Duration = duration;
    }

    /// <summary>
    /// уникальный идентификатор. 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя видеоролика
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание видеоролика
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Длительность видеоролика
    /// </summary>
    public TimeSpan Duration { get; set; }
}

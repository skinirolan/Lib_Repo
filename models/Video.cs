namespace Library_bvd53jkl.Models;

public class Video
{
     /// <summary>
    /// Конструктор модели
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="description">Описание</param>
    /// <param name="duration">Длительность</param>
    public Video(string name, string description, int duration)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Duration = TimeSpan.FromSeconds(duration);
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
    /// Длительность видеоролика в милисекундах
    /// </summary>
    public TimeSpan Duration { get; set; }
}

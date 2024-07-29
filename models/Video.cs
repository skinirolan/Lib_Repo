namespace Library_bvd53jkl.Models;

public class Video
{
    /// <summary>
    /// Конструктор модели, в котором требуется также ввести id. Оставлен для тестов.
    /// </summary>
    /// <param name="id">Уникальный номер</param>
    /// <param name="name">Имя</param>
    /// <param name="description">Описание</param>
    /// <param name="duration">Длительность в милисекундах</param>
    public Video(int id,string name, string description, int duration) 
    {
        Id = id;
        Name = name; 
        Description = description;
        Duration = duration;
    }

    /// <summary>
    /// Конструктор модели
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="description">Описание</param>
    /// <param name="duration">Длительность</param>
    public Video(string name, string description, int duration)
    {
        Id = 0;
        Name = name;
        Description = description;
        Duration = duration;
    }

    /// <summary>
    /// уникальный идентификатор. Задается с помощью VideoService. 
    /// </summary>
    public int Id { get; set; }

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
    public int Duration { get; set; }

    /// <summary>
    /// Метод "обнуления" ролика.
    /// Сначала я хотел, чтобы при ошибках возвращался некий "нулевой" ролик, но потом я всопмнил что могу просто возвращать код ошибки.
    /// </summary>
    public void NullVideo()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Duration = 0;
        this.Id = 0;
    }
}

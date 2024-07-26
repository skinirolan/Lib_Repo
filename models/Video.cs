namespace Library_bvd53jkl.Models;

public class Video
{
    /// <summary>
    /// Конструктор модели
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="duration"></param>
    public Video(int id,string name, string description, int duration) 
    {
        Id = id;
        Name = name; 
        Description = description;
        Duration = duration;
    }

    /// <summary>
    /// уникальный идентификатор
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

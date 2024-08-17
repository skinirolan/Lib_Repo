namespace Project_VH.Contract;

/// <summary>
/// Выходной ролик
/// </summary>
/// <param name="Id">Уникальный идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="Description">Описание</param>
/// <param name="Duration">Длительность</param>
public record VideoOutput (Guid Id, string Name, string Description, TimeSpan Duration);


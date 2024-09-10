namespace Project_VH.Contract;

/// <summary>
/// Входной ролик
/// </summary>
/// <param name="Name">Имя ролика</param>
/// <param name="Description">Описание ролика</param>
/// <param name="Duration">Длительность ролика</param>
public record VideoInput(string Name, string Description, TimeSpan Duration);
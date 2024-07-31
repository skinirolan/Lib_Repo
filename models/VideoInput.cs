namespace Library_bvd53jkl.models;

public record class VideoInput
{
    /// <summary>
    /// имя ролика
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// описание ролика
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// длительность ролика
    /// </summary>
    public int Duration { get; set; }
}

using Dal.DBContext;

namespace Dal.Repositories;

/// <summary>
/// Репозиторий для работы с бд
/// </summary>
public interface IVideoRepository
{

    /// <summary>
    /// Добавляет ролик в базу данных
    /// </summary>
    /// <param name="id">Уникалый идентификатор</param>
    /// <param name="name">Новое имя ролика</param>
    /// <param name="description">новая длительность ролика</param>
    /// <param name="duration">новая длительность ролика</param>
    /// <returns>ID добавленного ролика</returns>
    public Task<Guid> Add(VideoEntity videoEntity);

    /// <summary>
    /// Обновляет все данные о ролике
    /// </summary>
    /// <param name="id">Уникалый идентификатор</param>
    /// <param name="name">Новое имя ролика</param>
    /// <param name="description">новая длительность ролика</param>
    /// <param name="duration">новая длительность ролика</param>
    /// <returns>Ничего</returns>
    public Task Update(VideoEntity videoEntity);

    /// <summary>
    /// Удаление ролика из бд
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Ничего</returns>
    public Task Delete(Guid id);

    /// <summary>
    /// Получение всех роликов из бд
    /// </summary>
    /// <returns>Список роликов</returns>
    public Task<List<VideoEntity>> GetAll();

    /// <summary>
    /// Получение ролика из бд по id
    /// </summary>
    /// <param name="id">Уникалый идентификатор</param>
    /// <returns>Ролик</returns>
    public VideoEntity GetById(Guid id);
}

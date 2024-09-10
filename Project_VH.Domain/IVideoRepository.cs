using Project_VH.Domain.Entities;

namespace Project_VH.Domain.Repositories;

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
    /// <param name="description">Новая длительность ролика</param>
    /// <param name="duration">Новая длительность ролика</param>
    /// <returns>Ничего</returns>
    public Task Add(Video videoEntity);

    /// <summary>
    /// Обновляет все данные о ролике
    /// </summary>
    /// <param name="id">Уникалый идентификатор</param>
    /// <param name="name">Новое имя ролика</param>
    /// <param name="description">Новая длительность ролика</param>
    /// <param name="duration">Новая длительность ролика</param>
    /// <returns>Ничего</returns>
    public Task Update(Video videoEntity);

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
    public Task<List<Video>> GetAll();

    /// <summary>
    /// Получение ролика из бд по id
    /// </summary>
    /// <param name="id">Уникалый идентификатор</param>
    /// <returns>Ролик</returns>
    public Task<Video> GetById(Guid id);
}

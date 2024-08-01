using Library_bvd53jkl.Models;

namespace Library_bvd53jkl.Services;

public interface IVideoService
{

    /// <summary>
    /// Получение всех роликов
    /// </summary>
    /// <returns>List со всеми имеющимеся видеороликами</returns>
    List<Video> GetFullVideoList();

    /// <summary>
    /// Добавление ролика в список
    /// </summary>
    /// <param name="video">видеоролик</param>
    /// <returns>id добавленного видеоролика</returns>
    Guid Add(Video video);

    /// <summary>
    /// Удаление ролика из листа
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    void Delete(Guid id);

    /// <summary>
    /// Изменение параметров ролика соответствующего id
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <param name="videoinput">Ролик</param>
    void Update(Guid id,VideoInput videoinput);

    /// <summary>
    /// Получение ролика по id
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>видеоролик с соответствующим id</returns>
    Video Get(Guid id);

    /// <summary>
    /// Изменяет описание ролика
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <param name="description">Текст описания ролика</param>
    void UpdateDescription(Guid id, string description);


    /// <summary>
    /// Полная очистка списка
    /// </summary>
    void Clear();
}

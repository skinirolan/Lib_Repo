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
    /// <param name="id"></param>
    void Delete(Guid id);

    /// <summary>
    /// Изменение информации о ролике
    /// </summary>
    /// <param name="video"></param>
    void Update(Guid id,VideoInput videoinput);

    /// <summary>
    /// Получение ролика по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>видеоролик с соответствующим id</returns>
    Video Get(Guid id);

    /// <summary>
    /// Полная очистка списка
    /// </summary>
    void Clear();
}

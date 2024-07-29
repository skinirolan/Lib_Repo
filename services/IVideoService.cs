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
    int Add(Video video);

    /// <summary>
    /// Удаление ролика из листа
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);

    /// <summary>
    /// Изменение информации о ролике
    /// </summary>
    /// <param name="video"></param>
    void Update(Video video);

    /// <summary>
    /// Получение ролика по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>видеоролик с соответствующим id</returns>
    Video Get(int id);

    /// <summary>
    /// Полная очистка списка
    /// </summary>
    void Clear();
}

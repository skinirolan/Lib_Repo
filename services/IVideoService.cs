using Library_bvd53jkl.Models;

namespace Library_bvd53jkl.services
{
    public interface IVideoService
    {
        void add(Video video);
        void delete(int id);
        void update(Video video);
        Video get(int id);
    }
}

using Library_bvd53jkl.Models;

namespace Library_bvd53jkl.Services
{
    public interface IVideoService
    {
        List<Video>getFullVideoList();
        void add(Video video);
        void delete(int id);
        void update(Video video);
        Video get(int id);
        void clear();
    }
}

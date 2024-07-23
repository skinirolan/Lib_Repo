using Library_bvd53jkl.models;
using Library_bvd53jkl.services;
using Microsoft.AspNetCore.Mvc;

namespace Library_bvd53jkl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController:ControllerBase { 
        public VideoService _videoService;
        VideoController()
        {
            _videoService = new VideoService();
        }

        [HttpGet]
        public ActionResult<List<Video>> GetAllVideos()
        {
            return _videoService.GetFullVideoList();
        }
        [HttpPost]
        public ActionResult<Video> PostVideo(Video video)
        {
            _videoService.add(video);
            return Ok();
        }
    
    }
}

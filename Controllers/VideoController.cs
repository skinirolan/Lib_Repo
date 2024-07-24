using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_bvd53jkl.Controllers
{

    [ApiController]
    [Route("api/video")]
    public class VideoController:ControllerBase { 
        public VideoService _videoService;
        public VideoController(VideoService videoservice)
        {
            _videoService = videoservice;
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

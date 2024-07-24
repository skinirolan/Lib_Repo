﻿using Library_bvd53jkl.Models;
using Library_bvd53jkl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace Library_bvd53jkl.Controllers
{

    [ApiController]
    [Route("api/video")]
    public class VideoController : ControllerBase {
        public VideoService _videoService;
        public VideoController(VideoService videoservice)
        {
            _videoService = videoservice;
        }

        /// <summary>
        /// Позволяет получить все сохраненные ролики
        /// </summary>
        /// <returns>list со всеми Video</returns>
        [HttpGet]
        public ActionResult<List<Video>> GetAllVideos()
        {
            return _videoService.GetFullVideoList();
        }

        /// <summary>
        /// Позволяет получить видео по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Один конкретный Video по выбранному id</returns>
        [HttpGet("{id}")]
        public ActionResult<Video> GetVideoById(int id)
        {
            return _videoService.get(id);
        }

        /// <summary>
        /// Позволяет добавить ролик в память
        /// </summary>
        /// <param name="video"></param>
        /// <returns>Код результата</returns>
        [HttpPost]
        public ActionResult<Video> PostVideo(Video video)
        {
            _videoService.add(video);
            return Created();
        }

        /// <summary>
        /// позволяет удалить ролик из памяти
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Код результата</returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _videoService.delete(id);
            return Ok();
        }

        /// <summary>
        /// Позволяет обновить информацию о ролике. Меняется тот ролик, id которого был указан в запросе. Непосредсвтенно id поменять нельзя
        /// </summary>
        /// <param name="video"></param>
        /// <returns>Код результата</returns>
        [HttpPut]
        public ActionResult Put(Video video)
        {
            _videoService.update(video);
            return Ok();
        }
    
    }
}

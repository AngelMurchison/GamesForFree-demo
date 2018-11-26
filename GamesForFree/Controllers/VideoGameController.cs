using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamesForFree.Services;
namespace GamesForFree.Controllers
{
    public class VideoGameController : Controller
    {
        public IVideoGameService _videoGameService;

        public VideoGameController(IVideoGameService videoGameService)
        {
            this._videoGameService = videoGameService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var results = _videoGameService.Get();

            return Ok(results);
        }

        [HttpGet]
        public ActionResult AdminIndex()
        {
            var results = _videoGameService.GetForAdmin();

            return Ok(results);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var results = _videoGameService.GetDetails();

            return Ok(results);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var results = _videoGameService.Create();

            return Ok(results);
        }
    }
}
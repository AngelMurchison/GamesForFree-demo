using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesForFree.Models;
using GamesForFree.Services;
using GamesForFree.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesForFree.Controllers
{
    public class SeedController : Controller
    {
        public ISeedService _seedService;

        public SeedController(ISeedService seedService)
        {
            this._seedService = seedService;
        }

        [HttpPost]
        public ActionResult SeedFrom([FromBody]IList<VideoGameViewModel> viewModels)
        {
            _seedService.SeedFrom(viewModels);

            return Ok();
        }

		[HttpGet]
		public ActionResult SeedTransactions()
		{
			_seedService.SeedTransactions();
			return Ok();
		}

    }
}
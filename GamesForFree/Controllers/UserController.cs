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
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var results = _userService.Get();

            return Ok(results);
        }
        
        public ActionResult Details(UserValidationModel validationModel)
        {
            var results = _userService.GetDetails(validationModel);

            return Ok(results);
        }

        [HttpPost]
        public ActionResult Create([FromBody]User user)
        {
            var results = _userService.Create(user);

            return Ok(results);
        }

        [HttpPost]
        public ActionResult Validate([FromBody]UserValidationModel loginAttempt)
        {
            var results = _userService.Validate(loginAttempt);

            return Ok(results);
        }
    }
}
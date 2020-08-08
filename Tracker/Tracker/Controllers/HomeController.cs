using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tracker.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Google.Api;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using System.Runtime.InteropServices;

namespace Tracker.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("public")]
        public string Public()
        {
            return "This endpoint is public";
        }

        [Authorize]
        [HttpGet("protected")]
        public string Protected()
        {
            return "This endpoint is protected";
        }

        //public async Task<IActionResult> SignInAsync()
        //{
        //    FirebaseApp app = FirebaseApp.Create();
        //    FirebaseAuth auth = FirebaseAuth.GetAuth(app);
        //    UserRecordArgs args = new UserRecordArgs()
        //    {
        //        Uid = "Test-Uid",
        //        Email = "user@example.com",
        //        EmailVerified = false
        //    };
        //    UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
        //    return Ok("Signed in");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpAsync(LoginViewModel signinModel)
        {
            FirebaseApp app = FirebaseApp.Create();
            FirebaseAuth auth = FirebaseAuth.GetAuth(app);
            if (ModelState.IsValid)
            {
                UserRecordArgs args = new UserRecordArgs()
                {
                    Email = signinModel.Email,
                    EmailVerified = false,
                    Password = signinModel.Password
                };
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
            }
            return Ok("Signed in");
        }

        public IActionResult SignUp()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UserLogin([Bind] User user)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignInAsync()
        //{
        //    //UserRecordArgs args = new UserRecordArgs()
        //    //{
        //    //    Uid = "test-uid",
        //    //    Email = "user@example.com",
        //    //};
        //    //UserRecord record = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
        //    return Ok("logged in");
        //}


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
using AspNetCore.Firebase.Authentication;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Google.Apis.Util;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAsync(LoginViewModel loginModel)
        {

            //FirebaseApp app = FirebaseApp.Create();
            //FirebaseAuth auth = FirebaseAuth.GetAuth(app);
            //IReadOnlyDictionary<string, object> claims 
            //    = new Dictionary<string, object> 
            //{ 
            //        { "Email", loginModel.Email }, 
            //        { "Password", loginModel.Password }
            //};
            //UserRecord rec = await auth.GetUserByEmailAsync(loginModel.Email);
            //await auth.SetCustomUserClaimsAsync(rec.Uid, claims);

            //string token = await auth.CreateCustomTokenAsync(userRec.Uid);

            //if (ModelState.IsValid)
            //{

            //}



            //FirebaseApp app = FirebaseApp.Create();
            //FirebaseAuth auth = FirebaseAuth.GetAuth(app);

            //if(ModelState.IsValid)
            //{



            //    UserRecordArgs args = new UserRecordArgs()
            //    {   Email = loginModel.Email,
            //        Password = loginModel.Password
            //    };
            //    //FirebaseAuth.DefaultInstance.
            //    //UserRecord userRecord = await FirebaseAuth.DefaultInstance.
            //    //FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(User.)
            //    UserRecord fbUser = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(args.Email);
            //    try
            //    {
            //        var token = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(fbUser.Uid);
            //    }
            //    catch(Exception e)
            //    {
            //        return this.StatusCode(401, new { Error = e.Message });
            //    }
            //    //Firebase token = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(fbUser.Uid);
            //}
            return Ok("Logged in");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using Task = Tracker.Models.Task;

namespace Tracker.Controllers
{
    public class TestController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "fqBJG0xb4P06miU7cfhLv6bZ3KD0sM1iA9SUfF48",
            BasePath = "https://trackerapp-bf153.firebaseio.com/"
        };
        IFirebaseClient client;
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            try
            {
                AddTaskToFirebase(task);
                ModelState.AddModelError(string.Empty, "Added Successfully");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private void AddTaskToFirebase(Task task)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = task;
            PushResponse response = client.Push("Tasks/", data);
            data.task_id = response.Result.name;
            SetResponse setResponse = client.Set("Tasks/" + data.task_id, data);
        }
    }
}

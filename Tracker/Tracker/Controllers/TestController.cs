using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using Tracker.Models;
using ToDo = Tracker.Models.ToDo;

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

        [HttpGet]
        public async Task<IActionResult> ToDos()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = await client.GetAsync("Tasks/");
            Dictionary<string, ToDo> data = response.ResultAs<Dictionary<string, ToDo>>();
            ToDo task = data["-MD7UeOHRLc0-7pOlBIq"];
            return Ok(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDo task)
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

        private void AddTaskToFirebase(ToDo task)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = task;
            PushResponse response = client.Push("Tasks/", data);
            data.task_id = response.Result.name;
            SetResponse setResponse = client.Set("Tasks/" + data.task_id, data);
        }

        //private async void QueryTaskFromFirebase()
        //{
        //    client = new FireSharp.FirebaseClient(config);

        //    //FirebaseResponse resp = await client.GetAsync("branch/branch", obj);
        //    dynamic things = await client.GetAsync("Tasks");
        //    //Task t = resp.ResultAs<Task>();
        //    IAsyncEnumerable<Task> t = (IAsyncEnumerable<Task>)await client.GetAsync("Tasks");
        //}
    }
}

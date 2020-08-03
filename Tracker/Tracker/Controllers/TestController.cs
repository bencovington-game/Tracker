using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using Tracker.Models;
using Google.Cloud.Firestore;
using ToDo = Tracker.Models.ToDo;

namespace Tracker.Controllers
{
    public class TestController : Controller
    {
        //IFirebaseConfig config = new FirebaseConfig
        //{
        //    AuthSecret = "fqBJG0xb4P06miU7cfhLv6bZ3KD0sM1iA9SUfF48",
        //    BasePath = "https://trackerapp-bf153.firebaseio.com/"
        //};
        //IFirebaseClient client;

        [HttpGet]
        public async Task<IActionResult> ToDos()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"trackerapp-bf153-firebase-adminsdk-bwqab-9888d4cc15.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("trackerapp-bf153");
            CollectionReference usersRef = db.Collection("users");
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            int numTimes = 0;
            string userID = "";
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Console.WriteLine("User: {0}", document.Id);
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                numTimes++;
                userID = document.Id;
            }
            //client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = await client.GetAsync("Tasks/");
            //Dictionary<string, ToDo> data = response.ResultAs<Dictionary<string, ToDo>>();
            //ToDo task = data["-MD7UeOHRLc0-7pOlBIq"];
            return Ok("#: " + numTimes + " User: " + userID);
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
            //client = new FireSharp.FirebaseClient(config);
            //var data = task;
            //PushResponse response = client.Push("Tasks/", data);
            //data.task_id = response.Result.name;
            //SetResponse setResponse = client.Set("Tasks/" + data.task_id, data);
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

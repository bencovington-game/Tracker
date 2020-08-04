using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Firestore;
using Tracker.Models;

namespace Tracker.Controllers
{
    public class AppController : Controller
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\..\..\secrets\firebase-adminsdk.json";
        
        [HttpGet]
        public async Task<IActionResult> ProjectNotesAsync()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            FirestoreDb db = FirestoreDb.Create("trackerapp-bf153");

            Query query = db.Collection("projects").Document("project_id").Collection("notes");
            QuerySnapshot snap = await query.GetSnapshotAsync();

            List<Note> projectNotes = new List<Note>();
            foreach (DocumentSnapshot doc in snap.Documents)
            {
                Note n = doc.ConvertTo<Note>();
                projectNotes.Add(n);
            }
            return View(projectNotes);
        }
    }
}

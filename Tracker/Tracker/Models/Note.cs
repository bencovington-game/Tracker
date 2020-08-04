using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace Tracker.Models
{
    [FirestoreData]
    public class Note
    {
        [FirestoreDocumentId]
        public string NoteID { get; set; }

        [FirestoreDocumentCreateTimestamp]
        public Timestamp CreationDate { get; set; }

        [FirestoreDocumentUpdateTimestamp]
        public Timestamp? UpdateTimestamp { get; set; }

        [FirestoreProperty]
        public Timestamp? DueDate { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public Timestamp? CompletionDate { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        

    }
}

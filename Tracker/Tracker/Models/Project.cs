using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Tracker.Models
{
    [FirestoreData]
    public class Project
    {
        [FirestoreDocumentId]
        public string ProjectID { get; }

        [FirestoreDocumentCreateTimestamp]
        public Timestamp CreationDate { get; }

        [FirestoreDocumentUpdateTimestamp]
        public Timestamp? UpdateTimestamp { get; }

        [FirestoreProperty]
        public Timestamp? CompletionDate { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public Timestamp? DueDate { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public Timestamp? StartDate { get; set; }

    }
}

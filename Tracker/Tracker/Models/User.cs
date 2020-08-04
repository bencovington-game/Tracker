using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Tracker.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreDocumentId]
        public string UserID { get; }

        [FirestoreDocumentCreateTimestamp]
        public Timestamp CreationDate { get; }

        [FirestoreDocumentUpdateTimestamp]
        public Timestamp? UpdateTimestamp { get; }

        //[FirestoreProperty]
        //public string Description { get; set; }

        //[FirestoreProperty]
        //public string Name { get; set; }
    }
}

using MongoDB.Bson;
using System;

namespace BasketApp.Data.Documents
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}

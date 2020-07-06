using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BasketApp.Data.Entites
{
    public class Product
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

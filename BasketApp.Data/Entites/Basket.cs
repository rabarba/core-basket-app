using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BasketApp.Data.Entites
{
    public class Basket
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; }
        public List<Guid> ProductIdList { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BasketApp.Data.Entites
{
    public class Cart
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public List<long> ProductIdList { get; set; }
    }
}

using BasketApp.Core.Configs;
using BasketApp.Data.Entites;
using MongoDB.Driver;

namespace BasketApp.Data.Contexts
{
    public class BasketAppContext : IBasketAppContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public BasketAppContext(MongoDbConfig mongoDbConfig)
        {
            var mongoClient = new MongoClient(mongoDbConfig.ConnectionString);
            _mongoDatabase = mongoClient.GetDatabase(mongoDbConfig.Database);
        }

        public IMongoCollection<Product> Products => _mongoDatabase.GetCollection<Product>("Products");

        public IMongoCollection<Basket> Baskets => _mongoDatabase.GetCollection<Basket>("Baskets");
    }
}

using BasketApp.Core.Configs;
using BasketApp.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BasketApp.Data.Contexts
{
    public class BasketAppContext : IBasketAppContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public BasketAppContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _mongoDatabase = new MongoClient(mongoDbSettings.Value.ConnectionString).GetDatabase(mongoDbSettings.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products => _mongoDatabase.GetCollection<Product>("Products");

        public IMongoCollection<Cart> Carts => _mongoDatabase.GetCollection<Cart>("Carts");
    }
}

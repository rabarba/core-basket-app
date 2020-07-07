using BasketApp.Data.Configs;
using BasketApp.Data.Contexts;
using BasketApp.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBasketAppContext _basketAppContext;
        public ProductRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _basketAppContext = new BasketAppContext(mongoDbSettings);
        }

        public async Task<Product> Get(ObjectId productId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, productId);
            return await _basketAppContext.Products.Find(filter).FirstOrDefaultAsync();
        }
    }
}

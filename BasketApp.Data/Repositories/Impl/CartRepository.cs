using BasketApp.Core.Configs;
using BasketApp.Data.Contexts;
using BasketApp.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories.Impl
{
    public class CartRepository : ICartRepository
    {
        private readonly IBasketAppContext _basketAppContext;

        public CartRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _basketAppContext = new BasketAppContext(mongoDbSettings);
        }

        public async Task Create(Cart cart)
        {
            await _basketAppContext.Carts.InsertOneAsync(cart);
        }

        public async Task<Cart> Get(string cartId)
        {
            var objectId = new ObjectId(cartId);
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, objectId);
            return await _basketAppContext.Carts.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, cart.Id);
            await _basketAppContext.Carts.ReplaceOneAsync(filter, cart);
        }
    }
}

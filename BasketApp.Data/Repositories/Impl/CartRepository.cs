using BasketApp.Data.Configs;
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

        public async Task<string> Create(Cart cart)
        {
            await _basketAppContext.Carts.InsertOneAsync(cart);
            return cart.Id.ToString();
        }

        public async Task<Cart> Get(ObjectId cartId)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, cartId);
            return await _basketAppContext.Carts.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<string> Update(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, cart.Id);
            await _basketAppContext.Carts.ReplaceOneAsync(filter, cart);
            return cart.Id.ToString();
        }
    }
}

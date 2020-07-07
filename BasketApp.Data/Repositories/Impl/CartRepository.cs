using BasketApp.Data.Contexts;
using BasketApp.Data.Entites;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories.Impl
{
    public class CartRepository : ICartRepository
    {
        private readonly IBasketAppContext _basketAppContext;

        public CartRepository(BasketAppContext basketAppContext)
        {
            _basketAppContext = basketAppContext;
        }

        public async Task Create(Cart cart)
        {
            await _basketAppContext.Carts.InsertOneAsync(cart);
        }

        public async Task<Cart> Get(long cartId)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, cartId);
            return await _basketAppContext.Carts.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, cart.Id);
            await _basketAppContext.Carts.ReplaceOneAsync(filter, cart);
        }

        public async Task<long> GetId()
        {
            return await _basketAppContext.Carts.CountDocumentsAsync(new BsonDocument());
        }
    }
}

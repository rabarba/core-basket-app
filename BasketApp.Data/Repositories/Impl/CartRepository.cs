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

        public async Task Create(Cart Cart)
        {
            await _basketAppContext.Carts.InsertOneAsync(Cart);
        }

        public async Task<Cart> Get(long CartId)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, CartId);
            return await _basketAppContext.Carts.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(Cart Cart)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.Id, Cart.Id);
            await _basketAppContext.Carts.ReplaceOneAsync(filter, Cart);
        }

        public async Task<long> GetId()
        {
            return await _basketAppContext.Carts.CountDocumentsAsync(new BsonDocument());
        }
    }
}

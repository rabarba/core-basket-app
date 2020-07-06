using BasketApp.Data.Contexts;
using BasketApp.Data.Entites;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories.Impl
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketAppContext _basketAppContext;

        public BasketRepository(BasketAppContext basketAppContext)
        {
            _basketAppContext = basketAppContext;
        }

        public async Task Create(Basket basket)
        {
            await _basketAppContext.Baskets.InsertOneAsync(basket);
        }

        public async Task<Basket> Get(Guid basketId)
        {
            var filter = Builders<Basket>.Filter.Eq(x => x.Id, basketId);
            return await _basketAppContext.Baskets.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(Basket basket)
        {
            var filter = Builders<Basket>.Filter.Eq(x => x.Id, basket.Id);
            await _basketAppContext.Baskets.ReplaceOneAsync(filter, basket);
        }
    }
}

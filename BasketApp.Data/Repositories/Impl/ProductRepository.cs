using BasketApp.Data.Contexts;
using BasketApp.Data.Entites;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBasketAppContext _basketAppContext;
        public ProductRepository(IBasketAppContext basketAppContext)
        {
            _basketAppContext = basketAppContext;
        }
        public async Task<Product> Get(long productId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, productId);
            return await _basketAppContext.Products.Find(filter).FirstOrDefaultAsync();
        }
    }
}

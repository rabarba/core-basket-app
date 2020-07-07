using BasketApp.Data.Repositories;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BasketApp.Service.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> GetProductQuantity(ObjectId productId)
        {
            var product = await _productRepository.Get(productId);
            return product == null ? 0 : product.Quantity;
        }
    }
}

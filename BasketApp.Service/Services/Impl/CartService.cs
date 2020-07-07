using BasketApp.Data.Documents;
using BasketApp.Data.Repositories;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketApp.Service.Services.Impl
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<string> AddProductToExistingCart(Cart cart)
        {
            return await _cartRepository.Update(cart);
        }

        public async Task<string> AddProductToNotExistingCart(Cart cart)
        {
            return await _cartRepository.Create(cart);
        }

        public async Task<List<string>> GetProductsFromCart(ObjectId cartId)
        {
            var cart = await _cartRepository.Get(cartId);
            return cart?.ProductIdList;
        }
    }
}

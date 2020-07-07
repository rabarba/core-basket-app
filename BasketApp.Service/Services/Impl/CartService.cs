using BasketApp.Data.Documents;
using BasketApp.Data.Repositories;
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

        public async Task AddProductToExistingCart(Cart cart)
        {
            await _cartRepository.Update(cart);
        }

        public async Task AddProductToNotExistingCart(Cart cart)
        {
            await _cartRepository.Create(cart);
        }

        public async Task<List<string>> GetProductsFromCart(string cartId)
        {
            var Cart = await _cartRepository.Get(cartId);
            return Cart?.ProductIdList;
        }
    }
}

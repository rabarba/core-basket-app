using BasketApp.Data.Entites;
using BasketApp.Data.Repositories;
using System;
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

        public async Task<long> AddProductToExistingCart(Cart cart)
        {
            await _cartRepository.Update(cart);
            return cart.Id;
        }

        public async Task<long> AddProductToNotExistingCart(Cart cart)
        {
            var cartId = await _cartRepository.GetId() + 1;
            cart.Id = cartId;

            await _cartRepository.Create(cart);
            return cartId;
        }

        public async Task<List<long>> GetProductsFromCart(long cartId)
        {
            var Cart = await _cartRepository.Get(cartId);
            return Cart?.ProductIdList;
        }
    }
}

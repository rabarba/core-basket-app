using BasketApp.Data.Entites;
using BasketApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketApp.Service.Services.Impl
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task AddProductToExistingBasket(Basket basket)
        {
            await _basketRepository.Update(basket);
        }

        public async Task AddProductToNotExistingBasket(Basket basket)
        {
            await _basketRepository.Create(basket);
        }

        public async Task<List<Guid>> GetProductsFromBasket(Guid basketId)
        {
            var basket = await _basketRepository.Get(basketId);
            return basket?.ProductIdList;
        }
    }
}

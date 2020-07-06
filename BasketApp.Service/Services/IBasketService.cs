using BasketApp.Data.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketApp.Service.Services
{
    public interface IBasketService
    {
        Task<List<Guid>> GetProductsFromBasket(Guid basketId);

        Task AddProductToExistingBasket(Basket basket);

        Task AddProductToNotExistingBasket(Basket basket);
    }
}

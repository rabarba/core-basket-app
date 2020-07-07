using BasketApp.Data.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketApp.Service.Services
{
    public interface ICartService
    {
        Task<List<long>> GetProductsFromCart(long CartId);

        Task<long> AddProductToExistingCart(Cart Cart);

        Task<long> AddProductToNotExistingCart(Cart Cart);
    }
}

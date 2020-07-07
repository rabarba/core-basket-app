using System;
using System.Threading.Tasks;

namespace BasketApp.Service.Services
{
    public interface IProductService
    {
        Task<int> GetProductQuantity(string productId);
    }
}

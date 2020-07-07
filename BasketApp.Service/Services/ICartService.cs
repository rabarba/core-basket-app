using BasketApp.Data.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketApp.Service.Services
{
    public interface ICartService
    {
        Task<List<string>> GetProductsFromCart(string CartId);

        Task AddProductToExistingCart(Cart Cart);

        Task AddProductToNotExistingCart(Cart Cart);
    }
}

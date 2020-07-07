using BasketApp.Data.Documents;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketApp.Service.Services
{
    public interface ICartService
    {
        Task<List<string>> GetProductsFromCart(ObjectId CartId);

        Task<string> AddProductToExistingCart(Cart Cart);

        Task<string> AddProductToNotExistingCart(Cart Cart);
    }
}

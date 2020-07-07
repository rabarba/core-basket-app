using BasketApp.Data.Entites;
using System;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(long productId);
    }
}

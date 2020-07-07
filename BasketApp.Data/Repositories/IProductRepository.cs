using BasketApp.Data.Documents;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(string productId);
    }
}

using BasketApp.Data.Documents;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(ObjectId productId);
    }
}

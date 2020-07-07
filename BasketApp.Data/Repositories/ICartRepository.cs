using BasketApp.Data.Documents;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface ICartRepository
    {
        Task<string> Create(Cart cart);
        Task<Cart> Get(ObjectId cartId);
        Task<string> Update(Cart cart);
    }
}

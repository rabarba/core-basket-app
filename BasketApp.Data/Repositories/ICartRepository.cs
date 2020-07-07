using BasketApp.Data.Documents;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface ICartRepository
    {
        Task Create(Cart cart);
        Task<Cart> Get(string cartId);
        Task Update(Cart cart);
    }
}

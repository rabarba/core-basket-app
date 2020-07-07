using BasketApp.Data.Entites;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface ICartRepository
    {
        Task Create(Cart cart);
        Task<Cart> Get(long cartId);
        Task Update(Cart cart);
        Task<long> GetId();
    }
}

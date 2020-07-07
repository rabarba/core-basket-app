using BasketApp.Data.Entites;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface ICartRepository
    {
        Task Create(Cart Cart);
        Task<Cart> Get(long CartId);
        Task Update(Cart Cart);
        Task<long> GetId();
    }
}

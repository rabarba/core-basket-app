using BasketApp.Data.Entites;
using System;
using System.Threading.Tasks;

namespace BasketApp.Data.Repositories
{
    public interface IBasketRepository
    {
        Task Create(Basket basket);
        Task<Basket> Get(Guid basketId);
        Task Update(Basket basket);
    }
}

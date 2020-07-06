using BasketApp.Data.Entites;
using MongoDB.Driver;

namespace BasketApp.Data.Contexts
{
    public interface IBasketAppContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<Basket> Baskets { get; }
    }
}

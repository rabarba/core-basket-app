using BasketApp.Data.Entites;
using MongoDB.Driver;

namespace BasketApp.Data.Contexts
{
    public interface IBasketAppContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<Cart> Carts { get; }
    }
}

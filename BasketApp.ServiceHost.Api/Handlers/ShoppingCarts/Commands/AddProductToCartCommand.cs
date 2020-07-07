using MediatR;

namespace BasketApp.ServiceHost.Api.Handlers.ShoppingCarts.Commands
{
    public class AddProductToCartCommand : IRequest<string>
    {
        internal string ProductId { get; set; }
        public string CartId { get; set; }
    }
}

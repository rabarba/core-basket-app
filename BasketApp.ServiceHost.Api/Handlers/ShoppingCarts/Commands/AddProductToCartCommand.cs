using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BasketApp.ServiceHost.Api.Handlers.ShoppingCarts.Commands
{
    public class AddProductToCartCommand : IRequest<long>
    {
        [FromRoute]
        public long ProductId { get; set; }
        public Nullable<long> CartId { get; set; }
    }
}

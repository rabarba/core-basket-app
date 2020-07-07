using BasketApp.Core.Models.Exceptions;
using BasketApp.Data.Documents;
using BasketApp.Service.Services;
using MediatR;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BasketApp.ServiceHost.Api.Handlers.ShoppingCarts.Commands
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, string>
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public AddProductToCartCommandHandler(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public async Task<string> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(request.ProductId, out ObjectId productObjectId))
            {
                throw new ApiException("Wrong ProductId Format", System.Net.HttpStatusCode.BadRequest);
            }

            var productQuantity = await _productService.GetProductQuantity(productObjectId);

            if (productQuantity < 1)
            {
                throw new ApiException("Product not found", System.Net.HttpStatusCode.NotFound);
            }

            // CartId is null will be new cart scenario
            if (string.IsNullOrEmpty(request.CartId))
            {
                return await _cartService.AddProductToNotExistingCart(new Cart
                {
                    ProductIdList = new List<string> { request.ProductId }
                });
            }

            // CartId is not null will be existing cart scenario
            if (!ObjectId.TryParse(request.CartId, out ObjectId cartObjectId))
            {
                throw new ApiException("Wrong CartId Format", System.Net.HttpStatusCode.BadRequest);
            }

            var productIdList = await _cartService.GetProductsFromCart(cartObjectId);
            productIdList ??= new List<string>();
            productIdList.Add(request.ProductId);

            return await _cartService.AddProductToExistingCart(new Cart
            {
                Id = new ObjectId(request.CartId),
                ProductIdList = productIdList
            });

        }
    }
}

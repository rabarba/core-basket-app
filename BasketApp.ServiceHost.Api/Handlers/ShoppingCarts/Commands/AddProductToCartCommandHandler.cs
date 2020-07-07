using BasketApp.Data.Documents;
using BasketApp.Service.Services;
using MediatR;
using MongoDB.Bson;
using System;
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
            var productQuantity = await _productService.GetProductQuantity(request.ProductId);

            if (productQuantity < 1)
            {
                throw new Exception();
            }

            // CartId is null will be new cart scenario
            if (string.IsNullOrEmpty(request.CartId))
            {
                await _cartService.AddProductToNotExistingCart(new Cart
                {
                    ProductIdList = new List<string> { request.ProductId }
                });
            }
            else
            {
                var productIdList = await _cartService.GetProductsFromCart(request.CartId);
                productIdList.Add(request.ProductId);

                await _cartService.AddProductToExistingCart(new Cart
                {
                    Id = new ObjectId(request.CartId),
                    ProductIdList = productIdList
                });
            }

            return string.Empty;
        }
    }
}

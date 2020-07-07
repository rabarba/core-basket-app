using BasketApp.Data.Entites;
using BasketApp.Service.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BasketApp.ServiceHost.Api.Handlers.ShoppingCarts.Commands
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, long>
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public AddProductToCartCommandHandler(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public async Task<long> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            var productQuantity = await _productService.GetProductQuantity(request.ProductId);

            if (productQuantity < 1)
            {
                throw new Exception();
            }

            // CartId is null will be new cart scenario
            if (request.CartId == null)
            {
                return await _cartService.AddProductToNotExistingCart(new Cart
                {
                    ProductIdList = new List<long> { request.ProductId }
                });
            }
            else
            {
                var productIdList = await _cartService.GetProductsFromCart((long)request.CartId);
                productIdList.Add(request.ProductId);

                return await _cartService.AddProductToExistingCart(new Cart
                {
                    Id = (long)request.CartId,
                    ProductIdList = productIdList
                });
            }
        }
    }
}

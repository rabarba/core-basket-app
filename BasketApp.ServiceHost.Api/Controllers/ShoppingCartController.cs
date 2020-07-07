using BasketApp.ServiceHost.Api.Handlers.ShoppingCarts.Commands;
using BasketApp.ServiceHost.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BasketApp.ServiceHost.Api.Controllers
{
    [ApiController]
    [Route("api/shoppingcarts")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{productId}")]
        [ProducesResponseType(typeof(HttpServiceResponseBase<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromRoute] string productId, [FromBody] AddProductToCartCommand command)
        {
            command.ProductId = productId;
            var result = await _mediator.Send(command);
            return Ok(new HttpServiceResponseBase<string> { Data = result });
        }
    }
}

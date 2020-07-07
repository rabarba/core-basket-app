using BasketApp.ServiceHost.Api.Handlers.ShoppingCarts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("/{ProductId}")]
        public async Task<IActionResult> Post([FromBody]AddProductToCartCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

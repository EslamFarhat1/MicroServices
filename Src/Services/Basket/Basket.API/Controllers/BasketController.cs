using Basket.API.Entiites;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("GetShoppingCart/{userName}")]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult< ShoppingCart>> GetShoppingCart(string userName)
        {
            var basket=await _basketRepository.getBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }
        [HttpPost("UpdateShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppingCart(ShoppingCart cart)
        {
            return Ok(await _basketRepository.UpdateBasket(cart));
        }
        [HttpDelete("DeleteCart/{userName}")]
        public async Task<IActionResult> DeleteCart(string userName)
        {
            await _basketRepository.Delete(userName);
             return Ok();
        }
    }
}

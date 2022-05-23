using BusinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartItemController : ControllerBase
    {
        private ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartItem))]
        public async Task<IActionResult> Add([FromBody]CartItem cartItem)
        {
            return Ok(await _cartItemService.Add(cartItem));
        }
    }
}

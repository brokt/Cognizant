using BusinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CartItem>))]
        public async Task<IActionResult> GetCartList(int startIndex = 0, int count = 0)
        {
            return Ok(await _cartItemService.GetCartList(startIndex,count));
        }
        
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<int>))]
        public async Task<IActionResult> GetCountList()
        {
            return Ok(await _cartItemService.GetCountList());
        }
    }
}

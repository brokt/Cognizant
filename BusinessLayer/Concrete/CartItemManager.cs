using BusinessLayer.Abstract;
using DataLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartDal;
        private HttpContext _httpContext { get; }
        public CartItemManager(ICartItemDal cartDal, IHttpContextAccessor httpContextAccessor)
        {
            _cartDal = cartDal;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<CartItem> Add(CartItem cartItem)
        {
            var userId = Convert.ToInt32(this._httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            cartItem.UsersId = userId;
            _cartDal.Add(cartItem);
            await _cartDal.SaveChangesAsync();
            return cartItem;
        }
        public Task<List<CartItem>> GetCartList(int startIndex = 0, int count = 0)
        {
            var userId = Convert.ToInt32(this._httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _cartDal.Query().Where(g => g.UsersId == userId).Include(i => i.Vehicle).Skip(startIndex).Take(count).ToListAsync();
        }

        public Task<int> GetCountList()
        {
            var userId = Convert.ToInt32(this._httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var res = _cartDal.GetListAsync(g => g.UsersId == userId)
                .ContinueWith(gr =>  gr.Result.Count());
            return res;
        }
    }
}

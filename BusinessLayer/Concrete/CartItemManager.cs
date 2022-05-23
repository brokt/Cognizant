using DataLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartItemManager
    {
        private readonly ICartDal _cartDal;

        public CartItemManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public async Task<CartItem> Add(CartItem cartItem)
        {
            _cartDal.Add(cartItem);
            await _cartDal.SaveChangesAsync();
            return cartItem;
        }
    }
}

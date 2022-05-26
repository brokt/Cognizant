using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartItemService
    {
        Task<CartItem> Add(CartItem cartItem);
        Task<List<CartItem>> GetCartList(int startIndex = 0, int count = 0);
        Task<int> GetCountList();
    }
}

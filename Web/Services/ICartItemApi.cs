//<auto-generated />

using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Refit;

namespace Web.Services
{
    public interface ICartItemApi
    {
        [Post("/CartItem/Add")]
        [Headers("Authorization: Bearer")]
        Task<CartItem> Add([Body] CartItem cartItem);
        [Post("/CartItem/GetCartList")]
        [Headers("Authorization: Bearer")]
        Task<List<CartItem>> GetCartList(int startIndex = 0, int count = 0);
        [Get("/CartItem/GetCountList")]
        [Headers("Authorization: Bearer")]
        Task<int> GetCountList();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;

namespace Web.Pages
{
    public class CartListModel : PageModel
    {
        private HttpContext _httpContext { get; }

        private readonly IRefitApiRepository _refitApiRepository;
        
        [BindProperty]
        public List<CartItem> Item { get; set; }

        public CartListModel(IHttpContextAccessor httpContextAccessor, IRefitApiRepository refitApiRepository)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _refitApiRepository = refitApiRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var token = _httpContext.Session.GetString("Token");
            if (!string.IsNullOrEmpty(token))
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnPostReadAsync(int jtStartIndex = 0, int jtPageSize = 0)
        {
            var result = (List<CartItem>)await _refitApiRepository.GetClientService<ICartItemApi>().GetCartList(jtStartIndex, jtPageSize);
            return new JsonResult(new { Result = "OK", Records = result.Select(x => x.Vehicle), TotalRecordCount = await _refitApiRepository.GetClientService<ICartItemApi>().GetCountList() });
        }
    }
}

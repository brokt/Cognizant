using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;

namespace Web.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IVehicleApi _vehicleApi;
        private readonly ICartItemApi _cartItemApi;

        [BindProperty]
        public Vehicle Vehicle { get; set; }
        public DetailModel(IVehicleApi vehicleApi,ICartItemApi cartItemApi)
        {
            _vehicleApi = vehicleApi;
            _cartItemApi = cartItemApi;
        }
        public async Task OnGetAsync(int id)
        {
            Vehicle = await _vehicleApi.GetById(id);
        } 
        public IActionResult OnPost()
        {
            _cartItemApi.Add(new CartItem()
            {
                VehicleId = Vehicle.Id,
                Quantity = 1
            });
            return Page();
            //Vehicle = await _vehicleApi.GetById(id);
        }
    }
}

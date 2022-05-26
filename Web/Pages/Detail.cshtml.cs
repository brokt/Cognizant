using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
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
        private readonly IRefitApiRepository _refitApiRepository;

        [BindProperty]
        public Vehicle Vehicle { get; set; }
        public DetailModel(IVehicleApi vehicleApi, IRefitApiRepository refitApiRepository)
        {
            _vehicleApi = vehicleApi;
            _refitApiRepository = refitApiRepository;
        }
        public async Task OnGetAsync(int id)
        {
            Vehicle = await _vehicleApi.GetById(id);
        } 
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _refitApiRepository.GetClientService<ICartItemApi>().Add(new CartItem()
            {
                VehicleId = Vehicle.Id,
                Quantity = 1
            });
            
            Vehicle = await _vehicleApi.GetById(result.VehicleId);
            return Page();
            //Vehicle = await _vehicleApi.GetById(id);
        }
    }
}

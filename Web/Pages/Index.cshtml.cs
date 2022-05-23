using Core.Utilities.Mvc.Razor;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages
{
    public class IndexModel : PageBaseModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IVehicleApi _vehicleApi;
        public List<Vehicle> Vehicles;

        public IndexModel(ILogger<IndexModel> logger, IVehicleApi vehicleApi)
        {
            _logger = logger;
            _vehicleApi = vehicleApi;
        }

        public async Task OnGetAsync()
        {

        }
        public async Task<JsonResult> OnPostReadAsync(int jtStartIndex = 0, int jtPageSize = 0,string brandName = null)
        {
            var result = (List<Vehicle>)await _vehicleApi.GetCars(jtStartIndex,jtPageSize,brandName);
            return new JsonResult(new { Result = "OK", Records = result, TotalRecordCount = await _vehicleApi.GetCountList(brandName) });
        }
        public async Task<JsonResult> OnPostGetBrandsAsync()
        {
            return new JsonResult(new { results = await _vehicleApi.GetBrandList(), pagination = new { more = false } });
        }
    }
}

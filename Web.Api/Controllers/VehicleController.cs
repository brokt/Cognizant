using BusinessLayer.Abstract;
using Core.Entities;
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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DropDownDtos>))]
        public async Task<IActionResult> GetBrandListAsync()
        {
            return Ok(await _vehicleService.GetBrandList());
        } 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Vehicle>))]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await _vehicleService.GetList());
        }
        [HttpPost("{startIndex:int},{count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Vehicle>))]
        public async Task<IActionResult> GetCars(int startIndex = 0, int count = 0,string brandName = null)
        {
            return Ok(await _vehicleService.GetList(startIndex,count,brandName));
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehicle))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _vehicleService.GetById(id));
        } 
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetCountList(string brandName = null)
        {
            return Ok(await _vehicleService.GetCountList(brandName));
        }
    }
}

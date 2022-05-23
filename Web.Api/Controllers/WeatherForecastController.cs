using BusinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWareHouseService _wareHouseService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IWareHouseService wareHouseService)
        {
            _logger = logger;
            _wareHouseService = wareHouseService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var sa = System.IO.File.ReadAllText(@"C:\Users\bora.oktekin\Downloads\Cognizant Full Stack coding challenge warehouse v3\Cognizant Full Stack coding challenge warehouse v3\warehouses.json");
            var ss = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WareHouse>>(sa);
            ss.ForEach(f => { f.Id = 0;f.Cars.Vehicles.ForEach(fr => fr.Id = 0); });
            _wareHouseService.Add(ss);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

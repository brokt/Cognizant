//<auto-generated />

using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Web.Api;

namespace Web.Services
{
    public interface IWeatherForecastApi
    {
        [Get("/WeatherForecast")]
        Task<IEnumerable<WeatherForecast>> Get();
    }
}
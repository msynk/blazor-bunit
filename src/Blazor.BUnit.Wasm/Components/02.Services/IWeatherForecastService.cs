using System;
using System.Threading.Tasks;

namespace Blazor.BUnit.Wasm
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime dateTime);
    }
}

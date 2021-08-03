using Blazor.BUnit.Wasm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.BUnit.Tests
{
    public class DummyWeatherForecastService : IWeatherForecastService
    {
        public Task<WeatherForecast[]> GetForecastAsync(DateTime dateTime)
        {
            return Task.FromResult(Array.Empty<WeatherForecast>());
        }
    }
}

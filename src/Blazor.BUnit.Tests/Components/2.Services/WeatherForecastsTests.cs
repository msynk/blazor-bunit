using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class WeatherForecastsTests
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            // Register services
            ctx.Services.AddSingleton<IWeatherForecastService>(new DummyWeatherForecastService());

            // RenderComponent will inject the service in the WeatherForecasts component
            // when it is instantiated and rendered.
            var cut = ctx.RenderComponent<WeatherForecasts>();

            // Assert that service is injected
            Assert.IsNotNull(cut.Instance.Forecasts);
        }
    }
}
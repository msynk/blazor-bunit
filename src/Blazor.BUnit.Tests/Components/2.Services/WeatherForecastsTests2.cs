using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class WeatherForecastsTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            ctx.Services.AddFallbackServiceProvider(new FallbackServiceProvider());

            var dummyService = ctx.Services.GetService<DummyService>();

            Assert.IsNotNull(dummyService);
        }
    }
}
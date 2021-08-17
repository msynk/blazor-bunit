using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class AsyncAssertTests
    {
        [DataTestMethod,
            DataRow(2),
            DataRow(20)]
        public void Test(int id)
        {
            using var ctx = new Bunit.TestContext();
            ctx.Services.AddScoped<IDataService, DataService>();

            var cut = ctx.RenderComponent<AsyncAssert>(parameters => parameters.Add(p => p.Id, id));
            var p = cut.Find("p");

            //p.MarkupMatches($"<p>Data-{id}</p>");

            cut.WaitForAssertion(() => p.MarkupMatches($"<p>Data-{id}</p>"), TimeSpan.FromSeconds(2));
        }
    }
}

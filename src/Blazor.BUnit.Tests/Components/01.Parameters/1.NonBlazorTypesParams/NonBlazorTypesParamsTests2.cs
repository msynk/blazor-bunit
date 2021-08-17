using Blazor.BUnit.Wasm;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class NonBlazorTypesParamsTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var lines = new List<string> { "Hello", "World" };

            var cut = ctx.RenderComponent<NonBlazorTypesParams>(parameters => parameters
              .Add(p => p.Numbers, 42)
              .Add(p => p.Lines, lines)
            );
        }
    }
}

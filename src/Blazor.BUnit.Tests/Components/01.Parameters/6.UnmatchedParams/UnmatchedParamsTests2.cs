using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class UnmatchedParamsTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<UnmatchedParams>(parameters => parameters
              .AddUnmatched("some-unknown-param", "a value")
            );
        }
    }
}

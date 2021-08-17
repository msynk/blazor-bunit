using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class RenderFragmentParams2Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<RenderFragmentParams>(parameters => parameters
              .Add<Counter>(p => p.Content)
            );
        }
    }
}

using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class RenderFragmentParams1Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<RenderFragmentParams>(parameters => parameters
              .Add(p => p.Content, "<h1>Hello World</h1>")
            );
        }
    }
}

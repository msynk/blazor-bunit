using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class NestedComponentTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var wrapper = ctx.RenderComponent<Wrapper>(parameters => parameters
              .AddChildContent<HelloBlazor>()
            );
            var cut = wrapper.FindComponent<HelloBlazor>();
        }
    }
}

using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class RenderMeTests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<RenderMe>();
            Assert.AreEqual(1, cut.RenderCount);

            // Re-render without new parameters
            cut.Render();

            Assert.AreEqual(2, cut.RenderCount);
        }
    }
}

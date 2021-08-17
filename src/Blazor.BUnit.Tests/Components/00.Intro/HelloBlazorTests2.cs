using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class HelloBlazorTests2
    {
        [TestMethod]
        public void HelloBlazorComponentShouldRenderCorrectly()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();

            // Act
            var cut = ctx.RenderComponent<HelloBlazor>();

            // Assert
            cut.MarkupMatches("<h3>Hello from Blazor!</h3>");
        }
    }
}

using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class ButtonTests2 : BunitTestContext
    {
        [TestMethod]
        public void CounterComponentShouldRenderCorrectly()
        {
            // Arrange
            // it is implemented in the base class

            // Act
            var cut = RenderComponent<Button>(parameters => parameters.AddChildContent("<h1>hello</hello>"));

            // Assert
            cut.MarkupMatches("<button><h1>hello</h1></button>");
        }
    }
}

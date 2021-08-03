using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CounterTests2 : BunitTestContext
    {
        [TestMethod]
        public void Counter2ComponentShouldRenderCorrectly()
        {
            // Arrange
            // it is implemented in the base class
            int testCount = 0;

            // Act
            var cut = RenderComponent<Counter2>(parameters => parameters.Add(p => p.OnChange, v => testCount = v));
            var button = cut.Find("button");
            button.Click();
            button.Click();

            // Assert
            Assert.AreEqual(testCount, 2);
        }
    }
}
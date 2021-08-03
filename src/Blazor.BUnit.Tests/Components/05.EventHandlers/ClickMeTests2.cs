using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class ClickMeTests2
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<ClickMe>();
            var buttonElement = cut.Find("button");

            // Act
            buttonElement.Click();
            buttonElement.Click(detail: 3, ctrlKey: true);
            buttonElement.Click(new MouseEventArgs());

            // Assert
            // ...
        }
    }
}

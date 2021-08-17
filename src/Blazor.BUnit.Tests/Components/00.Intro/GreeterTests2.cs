using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class GreeterTests2 : BunitTestContext
    {
        [TestMethod,
            DataRow("Saleh"),
            DataRow("Yasser"),
            DataRow("Khashi"),
        ]
        public void GreeterComponentShouldRenderCorrectly(string name)
        {
            // Arrange
            // it is implemented in the base class

            // Act
            var par = ComponentParameter.CreateParameter("Name", name);
            var cut = RenderComponent<Greeter>(par);

            // Assert
            cut.MarkupMatches($"<h3>Hello {name}</h3>");
        }
    }
}

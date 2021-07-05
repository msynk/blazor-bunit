using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class RenderMeTests2
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<RenderMe>(parameters => parameters
              .Add(p => p.Value, "Value1")
            );
            cut.MarkupMatches("<div>Value1</div>");

            // Re-render with new parameters
            cut.SetParametersAndRender(parameters => parameters
              .Add(p => p.Value, "Value2")
            );

            cut.MarkupMatches("<div>Value2</div>");
        }
    }
}

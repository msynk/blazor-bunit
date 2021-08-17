using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<Calc>();

            // Indirectly re-renders through the call to StateHasChanged
            // in the Calculate(x, y) method.
            cut.InvokeAsync(() => cut.Instance.Calculate(1, 2));
            // cut.Instance.Calculate(1, 2);

            cut.MarkupMatches("<output>3</output>");
        }
    }
}

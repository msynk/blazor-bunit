using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CascadingParams1Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var isDarkTheme = true;

            var cut = ctx.RenderComponent<CascadingParams>(parameters => parameters
              .Add(p => p.IsDarkTheme, isDarkTheme)
            );
        }
    }
}

using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class VerifyMarkupTests
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<VerifyMarkup>();

            var renderedMarkup = cut.Markup;
            Assert.AreEqual("<h3>Verify Markup</h3>", renderedMarkup);
        }
    }
}

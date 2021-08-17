using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class MarkupMatchTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<MarkupMatch>();

            cut.MarkupMatches(@"<h3 id=""heading-1337"" required>Heading text<small class=""mark text-muted"">Secondary text</small></h3>");
        }

        [TestMethod]
        public void Test2()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<MarkupMatch>();

            var smallElm = cut.Find("small");
            smallElm.MarkupMatches(@"<small class=""mark text-muted"">Secondary text</small>");
        }

        [TestMethod]
        public void Test3()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<MarkupMatch>();

            var smallElmText = cut.Find("small").TextContent;
            smallElmText.MarkupMatches("Secondary text");
        }
    }
}

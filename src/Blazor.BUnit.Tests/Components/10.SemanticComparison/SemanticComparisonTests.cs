using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class SemanticComparisonTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<SemanticComparison>();

            var h1 = cut.Find("h1");

            var expected = @"<h1>Semantic Comparison</h1>";

            h1.MarkupMatches(expected);

            expected = @"<h1 diff:ignore></h1>";

            h1.MarkupMatches(expected);
        }

        [TestMethod]
        public void Test2()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<SemanticComparison>();

            var h2 = cut.Find("h2");

            var expected = @"<h2 class=""test"" required>This is test</h2>";

            h2.MarkupMatches(expected);

            expected = @"<h2 class:ignore required:ignore>This is test</h2>";

            h2.MarkupMatches(expected);
        }

        [TestMethod]
        public void Test3()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<SemanticComparison>();

            var h3 = cut.Find("h3");

            var expected = @"<h3>This is <b>test</b></h3>";

            h3.MarkupMatches(expected);

            expected = @"<h3 diff:whitespace=""preserve"">This is <b> test </b></h3>";

            h3.MarkupMatches(expected);
        }

        [TestMethod]
        public void Test3_5()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<SemanticComparison>();

            var pre = cut.Find("pre");

            var expected = @"<pre diff:whitespace=""normalize"">This is test<span>ttt</span></pre>";

            pre.MarkupMatches(expected);
        }

        [TestMethod]
        public void Test4()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<SemanticComparison>();

            var h4 = cut.Find("h4");

            var expected = @"<h4 class=""tEST"">tHIS IS Test</h4>";

            h4.MarkupMatches(expected);

            expected = @"<h4 class:ignoreCase=""test"" diff:ignoreCase>this is test</h4>";

            h4.MarkupMatches(expected);
        }



        [TestMethod]
        public void Test5()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<SemanticComparison>();

            var h5 = cut.Find("h5");

            var expected = @"<h5 title=""test title"">This is 2021</h5>";

            h5.MarkupMatches(expected);

            expected = @"<h5 title:regex=""test \w"" diff:regex>This is \d{4}</h5>";

            h5.MarkupMatches(expected);

            expected = @"<h5 title:regex:ignoreCase=""TEST \w"" diff:regex diff:ignoreCase>this is \d{4}</h5>";

            h5.MarkupMatches(expected);
        }
    }
}

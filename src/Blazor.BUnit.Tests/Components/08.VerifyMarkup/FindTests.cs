using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class FindTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<Find>();

            var tableCaption = cut.Find("caption");
            var tableCells = cut.FindAll("td:first-child");

            Assert.AreEqual(0, tableCaption.Attributes.Length);
            Assert.AreEqual(2, tableCells.Count);
            foreach (var td in tableCells)
            {
                Assert.IsTrue(td.HasAttribute("style"));
            }
        }

        [TestMethod]
        public void Test2()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<Find>(p => p.Add(f => f.Age, 20));

            var div = cut.Find("div");

            div.MarkupMatches("<div>Age: 20</div>");

            cut.SetParametersAndRender(p => p.Add(f => f.Age, 30));

            div.MarkupMatches("<div>Age: 30</div>");
        }

        [TestMethod]
        public void Test3()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<Find>(p => p.Add(f => f.Age, 20));

            var allDivs = cut.FindAll("div", true);

            Assert.IsTrue(allDivs.Count == 2);
            Assert.AreEqual(allDivs.Count, 2);

            foreach (var div in allDivs)
            {
                div.MarkupMatches("<div>Age: 20</div>");
            }

            cut.SetParametersAndRender(p => p.Add(f => f.Age, 30));

            Assert.IsTrue(allDivs.Count == 2);
            Assert.AreEqual(allDivs.Count, 2);

            foreach (var div in allDivs)
            {
                div.MarkupMatches("<div>Age: 30</div>");
            }
        }
    }
}

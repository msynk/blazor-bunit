using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CounterDiffTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<CounterDiff>();

            cut.Find("button").Click();
            var diffs = cut.GetChangesSinceFirstRender();
            var diff = diffs.ShouldHaveSingleChange();

            diff.ShouldBeTextChange("Current count: 1");
        }
    }
}

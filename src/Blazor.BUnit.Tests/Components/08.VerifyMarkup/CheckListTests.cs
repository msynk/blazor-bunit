using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CheckListTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<CheckList>();
            var inputField = cut.Find("input");

            inputField.Change("First item");
            inputField.KeyUp(key: "Enter");

            var diffs = cut.GetChangesSinceFirstRender();
            diffs
              .ShouldHaveSingleChange()
              .ShouldBeAddition("<li>First item</li>");

            cut.SaveSnapshot();

            inputField.Change("Second item");
            inputField.KeyUp(key: "Enter");

            diffs = cut.GetChangesSinceFirstRender();
            diffs.ShouldHaveChanges(
              diff => diff.ShouldBeAddition("<li>First item</li>"),
              diff => diff.ShouldBeAddition("<li>Second item</li>")
            );

            diffs = cut.GetChangesSinceSnapshot();
            diffs
              .ShouldHaveSingleChange()
              .ShouldBeAddition("<li>Second item</li>");

            cut.SaveSnapshot();

            cut.Find("li:last-child").Click();

            diffs = cut.GetChangesSinceFirstRender();
            diffs.ShouldHaveChanges(
              diff => diff.ShouldBeAddition("<li>First item</li>")
            );

            diffs = cut.GetChangesSinceSnapshot();
            diffs
              .ShouldHaveSingleChange()
              .ShouldBeRemoval("<li>Second item</li>");
        }
    }
}

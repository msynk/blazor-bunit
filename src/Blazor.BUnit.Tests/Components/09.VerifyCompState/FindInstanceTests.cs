using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class FindInstanceTests
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<FindInstance>(p => p.Add(f => f.Count, 3));

            var firstComp = cut.FindComponent<VerifyState>();
            var comps = cut.FindComponents<VerifyState>();

            Assert.AreEqual(3, comps.Count);
        }
    }
}

using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CascadingParams2Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<CascadingParams>(parameters => parameters
              .Add(p => p.UserName, "Name of User")
            );
        }
    }
}
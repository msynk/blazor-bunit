using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class CascadingParams3Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var isDarkTheme = true;

            var cut = ctx.RenderComponent<CascadingParams>(parameters => parameters
              .Add(p => p.IsDarkTheme, isDarkTheme)
              .Add(p => p.UserName, "Name of User")
              .Add(p => p.Email, "user@example.com")
            );
        }
    }
}
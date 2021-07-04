using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class ChildContentParams3Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<ChildContentParams>(parameters => parameters
              .AddChildContent<Alert>(alertParameters => alertParameters
                .Add(p => p.Heading, "Alert heading")
                .Add(p => p.Type, AlertType.Warning)
                .AddChildContent("<p>Hello World</p>")
              )
            );
        }
    }
}
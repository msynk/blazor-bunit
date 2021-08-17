using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class RenderFragmentParams3Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<RenderFragmentParams>(parameters => parameters
              .Add<Alert>(p => p.Content, alertParameters => alertParameters
                .Add(p => p.Heading, "Alert heading")
                .Add(p => p.Type, AlertType.Warning)
                .AddChildContent("<p>Hello World</p>")
              )
            );
        }
    }
}

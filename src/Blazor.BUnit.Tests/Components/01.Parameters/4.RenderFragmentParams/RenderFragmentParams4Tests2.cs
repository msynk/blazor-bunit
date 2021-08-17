using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class RenderFragmentParams4Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<RenderFragmentParams>(parameters => parameters
              .Add(p => p.Content, "<h1>Below you will find a most interesting alert!</h1>")
              .Add<Alert>(p => p.Content, childParams => childParams
                .Add(p => p.Heading, "Alert heading")
                .Add(p => p.Type, AlertType.Warning)
                .AddChildContent("<p>Hello World</p>")
              )
            );
        }
    }
}

using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class ChildContentParams4Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<ChildContentParams>(parameters => parameters
              .AddChildContent("<h1>Below you will find a most interesting alert!</h1>")
              .AddChildContent<Alert>(childParams => childParams
                .Add(p => p.Heading, "Alert heading")
                .Add(p => p.Type, AlertType.Warning)
                .AddChildContent("<p>Hello World</p>")
              )
            );
        }
    }
}

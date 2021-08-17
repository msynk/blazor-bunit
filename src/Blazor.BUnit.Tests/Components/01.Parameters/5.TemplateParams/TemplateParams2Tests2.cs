using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class TemplateParams2Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<TemplateParams<string>>(parameters => parameters
              .Add(p => p.Items, new[] { "Foo", "Bar", "Baz" })
              .Add<ChildItem, string>(p => p.Temp, v => itemParams => itemParams
                .Add(p => p.Value, v)
              )
            );
        }
    }
}

using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class TemplateParams1Tests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var cut = ctx.RenderComponent<TemplateParams<string>>(parameters => parameters
              .Add(p => p.Items, new[] { "Foo", "Bar", "Baz" })
              .Add(p => p.Temp, item => $"<span>{item}</span>")
            );
        }
    }
}

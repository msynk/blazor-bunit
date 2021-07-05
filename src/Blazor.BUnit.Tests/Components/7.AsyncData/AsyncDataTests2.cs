using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class AsyncDataTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();
            var textService = new TaskCompletionSource<string>();
            var cut = ctx.RenderComponent<AsyncData>(parameters => parameters
              .Add(p => p.TextService, textService.Task)
            );

            // Act - set the awaited result from the text service
            textService.SetResult("Hello World");

            // Wait for state before continuing test
            cut.WaitForState(() => cut.Find("p").TextContent == "Hello World", TimeSpan.FromSeconds(5));

            // Assert - verify result has been set
            cut.MarkupMatches("<p>Hello World</p>");
        }
    }
}

using Bunit;
using Blazor.BUnit.Wasm;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class AsyncDataTests
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();
            var textService = new TaskCompletionSource<string>();
            var cut = ctx.RenderComponent<AsyncData>(parameters => parameters
              .Add(p => p.TextService, textService.Task)
            );
            var text = "Hello World";

            // Act - set the awaited result from the text service
            textService.SetResult(text);

            // Wait for state before continuing test
            cut.WaitForState(() => cut.Find("p").TextContent == text);

            // Assert - verify result has been set
            cut.MarkupMatches($"<p>{text}</p>");
        }
    }
}

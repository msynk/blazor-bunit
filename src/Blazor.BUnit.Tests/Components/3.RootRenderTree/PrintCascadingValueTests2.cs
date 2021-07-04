using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class PrintCascadingValueTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            // Add a cascading value to the test contexts root render tree.
            var isAdded = ctx.RenderTree.TryAdd<CascadingValue<string>>(parameters => parameters
              .Add(p => p.Value, "BAR?")
            );

            // The component will be rendered as a chld of last 
            // component added to the RenderTree property.
            var cut = ctx.RenderComponent<PrintCascadingValue>();

            // Verify that the cascading value was passed correctly.
            cut.MarkupMatches($"Cascading value: BAR?");
        }
    }
}
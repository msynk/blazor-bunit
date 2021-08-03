using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class EventCallbackParamsTests2
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            Action<MouseEventArgs> onClickHandler = _ => { };
            Action onSomethingHandler = () => { };

            var cut = ctx.RenderComponent<EventCallbackParams>(parameters => parameters
              .Add(p => p.OnClick, onClickHandler)
              .Add(p => p.OnSomething, onSomethingHandler)
            );
        }
    }
}
using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class JSRuntimeTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;

            var cut = ctx.RenderComponent<JsInvoke>();

            var span = cut.Find("span");
            var invokeButton = cut.Find("button.invoke");
            var invokeVoidButton = cut.Find("button.invoke-void");

            span.MarkupMatches("<span>result: </span>");

            invokeButton.Click();

            span.MarkupMatches("<span>result: null</span>");

            invokeVoidButton.Click();

            span.MarkupMatches("<span>result: InvokeVoid</span>");
        }

        [TestMethod]
        public void Test2()
        {
            using var ctx = new Bunit.TestContext();
            var result = "bUnit Invoke";
            ctx.JSInterop.Setup<string>("TestInvoke").SetResult(result);
            ctx.JSInterop.SetupVoid("TestInvokeVoid").SetVoidResult();

            var cut = ctx.RenderComponent<JsInvoke>();

            var span = cut.Find("span");
            var invokeButton = cut.Find("button.invoke");
            var invokeVoidButton = cut.Find("button.invoke-void");

            span.MarkupMatches("<span>result: </span>");

            invokeButton.Click();

            span.MarkupMatches($"<span>result: {result}</span>");

            invokeVoidButton.Click();

            span.MarkupMatches("<span>result: InvokeVoid</span>");
        }

        [TestMethod]
        public void Test3()
        {
            using var ctx = new Bunit.TestContext();
            var result = "bUnit Invoke";

            var invocationHandler = ctx.JSInterop.Setup<string>("TestInvoke");
            var invocationVoidHandler = ctx.JSInterop.SetupVoid("TestInvokeVoid");

            var cut = ctx.RenderComponent<JsInvoke>();

            var span = cut.Find("span");
            var invokeButton = cut.Find("button.invoke");
            var invokeVoidButton = cut.Find("button.invoke-void");

            span.MarkupMatches("<span>result: </span>");

            invocationHandler.SetResult(result);

            invokeButton.Click();

            span.MarkupMatches($"<span>result: {result}</span>");

            invocationHandler.SetResult("testt");

            invokeButton.Click();

            span.MarkupMatches($"<span>result: testt</span>");

            invocationVoidHandler.SetVoidResult();

            invokeVoidButton.Click();

            span.MarkupMatches("<span>result: InvokeVoid</span>");
        }
    }
}

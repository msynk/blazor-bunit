using Bunit;
using System;
using System.Net;
using System.Net.Http;
using Blazor.BUnit.Wasm;
using RichardSzalay.MockHttp;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class FakeHttpClientTests
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();

            var mockHttpHandler = new MockHttpMessageHandler();
            var httpClient = mockHttpHandler.ToHttpClient();
            httpClient.BaseAddress = new Uri("http://saleh.bit.com");
            ctx.Services.AddSingleton(httpClient);

            var result = "this is the getUsers response";
            mockHttpHandler.When("/getUsers").Respond(async () =>
            {
                await Task.Delay(900);
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(result) };
            });

            var cut = ctx.RenderComponent<FakeHttpClient>();
            var button = cut.Find("button");
            var span = cut.Find("span");

            button.Click();

            //span.MarkupMatches($"<span>result: {result}</span>");
            cut.WaitForAssertion(() => span.MarkupMatches($"<span>result: {result}</span>"));
        }
    }
}

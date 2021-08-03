﻿using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class VerifyStateTests
    {
        [TestMethod]
        public void Test()
        {
            using var ctx = new Bunit.TestContext();
            IRenderedComponent<VerifyState> cut = ctx.RenderComponent<VerifyState>();

            VerifyState alert = cut.Instance;
            alert.Age = 20;
            alert.Name = "Saleh";            

            Assert.AreEqual(alert.Greet(), "Hello Saleh");

        }
    }
}

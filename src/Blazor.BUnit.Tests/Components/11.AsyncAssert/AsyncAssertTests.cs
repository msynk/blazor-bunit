﻿using Bunit;
using Blazor.BUnit.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class AsyncAssertTests
    {
        [DataTestMethod,
            DataRow(2),
            DataRow(20)]
        public void Test(int id)
        {
            using var ctx = new Bunit.TestContext();
            ctx.Services.AddScoped<IDataService, DataService>();

            var cut = ctx.RenderComponent<AsyncAssert>(parameters => parameters.Add(p => p.Id, id));
            var p = cut.Find("p");

            cut.WaitForAssertion(() => p.MarkupMatches($"<p>Data-{id}</p>"), TimeSpan.FromSeconds(2));
        }
    }
}

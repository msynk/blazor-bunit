using Bunit;
using Blazor.BUnit.Wasm;
using Bunit.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class UserInfoTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            ctx.AddTestAuthorization();

            var cut = ctx.RenderComponent<UserInfo>();

            cut.MarkupMatches(@"<h1>User Info</h1>
                                <h1>Please log in!</h1>
                                <p>State: Not authorized</p>");
        }

        [TestMethod]
        public void Test2()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorizing();

            var cut = ctx.RenderComponent<UserInfo>();

            cut.MarkupMatches(@"<h1>User Info</h1>
                                <h1>Please log in!</h1>
                                <p>State: Authorizing</p>");
        }

        [TestMethod]
        public void Test3()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();
            var username = "saleh";
            authContext.SetAuthorized(username, AuthorizationState.Unauthorized);

            var cut = ctx.RenderComponent<UserInfo>();

            cut.MarkupMatches(@$"<h1>User Info</h1>
                                <h1>Welcome {username}</h1>
                                <p>State: Not authorized</p>");
        }

        [TestMethod]
        public void Test4()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();
            var username = "saleh";
            authContext.SetAuthorized(username);

            var cut = ctx.RenderComponent<UserInfo>();

            cut.MarkupMatches(@$"<h1>User Info</h1>
                                <h1>Welcome {username}</h1>
                                <p>State: Authorized</p>");
        }
    }
}

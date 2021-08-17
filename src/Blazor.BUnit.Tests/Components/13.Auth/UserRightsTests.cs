using Bunit;
using Blazor.BUnit.Wasm;
using Bunit.TestDoubles;
using System.Security.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blazor.BUnit.Tests
{
    [TestClass]
    public class UserRightsTests
    {
        [TestMethod]
        public void Test1()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();

            var username = "saleh";
            authContext.SetAuthorized(username);

            var role = "admin";
            authContext.SetRoles(role);

            var cut = ctx.RenderComponent<UserRights>();

            cut.MarkupMatches(@$"<h1>User Rights</h1>
                                <h1>Hi {username}, you have these claims and rights:</h1>
                                <ul>
                                  <li>You have the role «{role}»</li>
                                </ul>");
        }

        [TestMethod]
        public void Test2()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();

            var username = "saleh";
            authContext.SetAuthorized(username);

            var role1 = "admin";
            var role2 = "staff";
            authContext.SetRoles(role1, role2);

            var cut = ctx.RenderComponent<UserRights>();

            cut.MarkupMatches(@$"<h1>User Rights</h1>
                                <h1>Hi {username}, you have these claims and rights:</h1>
                                <ul>
                                  <li>You have the role «{role1}»</li>
                                  <li>You have the role «{role2}»</li>
                                </ul>");
        }

        [TestMethod]
        public void Test3()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();

            var username = "saleh";
            authContext.SetAuthorized(username);

            var policy = "editor";
            authContext.SetPolicies(policy);

            var cut = ctx.RenderComponent<UserRights>();

            cut.MarkupMatches(@$"<h1>User Rights</h1>
                                <h1>Hi {username}, you have these claims and rights:</h1>
                                <ul>
                                  <li>You are a «{policy}»</li>
                                </ul>");
        }

        [TestMethod]
        public void Test4()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();

            var username = "saleh";
            authContext.SetAuthorized(username);

            var policy1 = "editor";
            var policy2 = "approver";
            authContext.SetPolicies(policy1, policy2);

            var cut = ctx.RenderComponent<UserRights>();

            cut.MarkupMatches(@$"<h1>User Rights</h1>
                                <h1>Hi {username}, you have these claims and rights:</h1>
                                <ul>
                                  <li>You are a «{policy1}»</li>
                                  <li>You are a «{policy2}»</li>
                                </ul>");
        }

        [TestMethod]
        public void Test5()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();

            var username = "saleh";
            authContext.SetAuthorized(username);

            var email = "saleh@bit.com";
            var country = "iran";
            authContext.SetClaims(
              new Claim(ClaimTypes.Email, email),
              new Claim(ClaimTypes.Country, country)
            );

            var cut = ctx.RenderComponent<UserRights>();

            cut.MarkupMatches(@$"<h1>User Rights</h1>
                                <h1>Hi {username}, you have these claims and rights:</h1>
                                <ul>
                                  <li>emailaddress: {email}</li>
                                  <li>country: {country}</li>
                                </ul>");
        }

        [TestMethod]
        public void Test6()
        {
            using var ctx = new Bunit.TestContext();
            var authContext = ctx.AddTestAuthorization();

            var username = "saleh";
            authContext.SetAuthorized(username);

            var role1 = "admin";
            var role2 = "staff";
            authContext.SetRoles(role1, role2);

            var policy1 = "editor";
            var policy2 = "approver";
            authContext.SetPolicies(policy1, policy2);

            var email = "saleh@bit.com";
            var country = "iran";
            authContext.SetClaims(
              new Claim(ClaimTypes.Email, email),
              new Claim(ClaimTypes.Country, country)
            );

            var cut = ctx.RenderComponent<UserRights>();

            cut.MarkupMatches(@$"<h1>User Rights</h1>
                                <h1>Hi {username}, you have these claims and rights:</h1>
                                <ul>
                                  <li>You have the role «{role1}»</li>
                                  <li>You have the role «{role2}»</li>

                                  <li>You are a «{policy1}»</li>
                                  <li>You are a «{policy2}»</li>

                                  <li>emailaddress: {email}</li>
                                  <li>country: {country}</li>
                                </ul>");
        }
    }
}

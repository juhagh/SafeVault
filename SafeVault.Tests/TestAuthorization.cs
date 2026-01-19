using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using SafeVault.Security;
using System.Collections.Generic;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuthorization
    {
        [Test]
        public void NonAdmin_User_IsForbidden_FromAdminResource()
        {
            TestContext.WriteLine("Running InvalidPassword_IsRejected");
            // Arrange
            var httpContext = new DefaultHttpContext();
            httpContext.Session = new TestSession();
            httpContext.Session.SetString("Role", "User");

            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),               // ✅ required
                new ActionDescriptor()         // ✅ required
            );

            var filterContext = new AuthorizationFilterContext(
                actionContext,
                new List<IFilterMetadata>()
            );

            var attribute = new RoleAuthorizeAttribute("Admin");

            // Act
            attribute.OnAuthorization(filterContext);

            // Assert
            Assert.That(filterContext.Result, Is.TypeOf<ForbidResult>());
        }
    }
}
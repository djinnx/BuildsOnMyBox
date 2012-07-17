namespace BOMB.Web.Core.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using BOMB.Web.Models;

    /// <summary>
    /// Authorization attribute
    /// </summary>
    public class MustBeLoggedInAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if the user is authorized; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="httpContext"/> parameter is null.</exception>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity != null && httpContext.User.Identity is FormsIdentity)
            {
                UserState userState = new UserState();
                userState.FromString(((FormsIdentity)httpContext.User.Identity).Ticket.UserData);

                if (userState.Valid)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Processes HTTP requests that fail authorization.
        /// </summary>
        /// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute"/>. The <paramref name="filterContext"/> object contains the controller, HTTP context, request context, action result, and route data.</param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            IPrincipal user = filterContext.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}
namespace BOMB.Web.Tests.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core.Extensions;
    using System.Web.Routing;
    using BOMB.Web.Areas.Testing;
    using System.Web.Mvc;

    /// <summary>
    /// Testing Base class, used by all test classes
    /// </summary>
    public class TestBase
    {
        internal void GetApplicationRoutes()
        {
            //Make sure to add additional area routes to this method.
            RouteTable.Routes.Clear();
            var testingArea = new TestingAreaRegistration();
            testingArea.RegisterArea(new AreaRegistrationContext(testingArea.AreaName, RouteTable.Routes));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

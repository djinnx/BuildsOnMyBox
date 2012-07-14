namespace BOMB.Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BOMB.Web.Tests.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BOMB.Web.Tests.Core.Extensions;

    [TestClass]
    public class RouteTests : TestBase
    {
        [TestInitialize]
        public void Setup()
        {
            base.GetApplicationRoutes();
        }

        [TestMethod]
        public void Default_Url_Should_Go_To_Home_Controller_Index_Action()
        {
            "~/".Route().ShouldMapTo<BOMB.Web.Controllers.HomeController>(action => action.Index());
        }

        [TestMethod]
        public void Home_Should_Go_To_Home_Controller_Index_Action()
        {
            "~/Home".Route().ShouldMapTo<BOMB.Web.Controllers.HomeController>(action => action.Index());
        }

        [TestMethod]
        public void Home_Index_Should_Go_To_Home_Controller_Index_Action()
        {
            "~/Home/Index".Route().ShouldMapTo<BOMB.Web.Controllers.HomeController>(action => action.Index());
        }

    
    }
}

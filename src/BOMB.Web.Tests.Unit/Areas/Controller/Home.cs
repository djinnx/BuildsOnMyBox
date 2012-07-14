using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOMB.Web.Areas.Testing.Controllers;
using System.Web.Mvc;
using BOMB.Web.Tests.Core;
using BOMB.Web.Tests.Core.Extensions;

namespace BOMB.Web.Tests.Areas.Controller
{
    [TestClass]
    public class Home : TestBase
    {
        [TestMethod]
        public void Index_Action_Returns_Index_View()
        {
            ActionResult result = new HomeController().Index();
            result.AssertViewRendered().ForViewEndingWith("Index.cshtml");
        }

        [TestMethod]
        public void About_Action_Returns_About_View()
        {
            ActionResult result = new HomeController().About();
            result.AssertViewRendered().ForViewEndingWith("About.cshtml");
        }
    }
}

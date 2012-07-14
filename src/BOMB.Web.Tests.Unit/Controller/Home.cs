using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOMB.Web.Controllers;
using System.Web.Mvc;
using BOMB.Web.Tests.Core;
using BOMB.Web.Tests.Core.Extensions;
using BOMB.Core.Services;
using Moq;

namespace BOMB.Web.Tests.Controller
{
    [TestClass]
    public class Home : TestBase
    {
        [TestMethod]
        public void Index_Action_Returns_Index_View()
        {
            ActionResult result = new HomeController(new Mock<IAccountService>(MockBehavior.Loose).Object).Index();
            result.AssertViewRendered().ForViewEndingWith("Index.cshtml");
        }

        [TestMethod]
        public void About_Action_Returns_About_View()
        {
            ActionResult result = new HomeController(new Mock<IAccountService>(MockBehavior.Loose).Object).About();
            result.AssertViewRendered().ForViewEndingWith("About.cshtml");            
        }
    }
}

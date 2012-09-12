namespace BOMB.Web.Areas.Testing.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Home Controller
    /// </summary>
    public partial class HomeController : Controller
    {
        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns>Returns the Index action</returns>
        public virtual ActionResult Index()
        {
            return this.View(this.Views.Index);
        }

        /// <summary>
        /// About action
        /// </summary>
        /// <returns>Returns the About action</returns>
        public virtual ActionResult About()
        {
            return this.View(this.Views.About);
        }
    }
}

namespace BOMB.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using BOMB.Core.Services;

    /// <summary>
    ///   The Home Controller
    /// </summary>
    public partial class HomeController : BaseController
    {
        /// <summary>
        ///   The index Action
        /// </summary>
        /// <returns> returns the index view </returns>
        public virtual ActionResult Index()
        {
            return this.View(this.Views.Index);
        }

        /// <summary>
        /// The about.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public virtual ActionResult About()
        {
            return this.View(this.Views.About);
        }
    }
}
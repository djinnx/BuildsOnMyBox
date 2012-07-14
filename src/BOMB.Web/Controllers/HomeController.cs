namespace BOMB.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using BOMB.Core.Services;

    /// <summary>
    ///   The Home Controller
    /// </summary>
    public partial class HomeController : Controller
    {
        /// <summary>
        /// Backing variable for the account service
        /// </summary>
        private IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController() : this(new AccountService())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        public HomeController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

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
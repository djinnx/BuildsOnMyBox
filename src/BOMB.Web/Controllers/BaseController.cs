namespace BOMB.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using BOMB.Core.Services;
    using BOMB.Domain;
    using BOMB.Web.Models;
    using Ninject;

    /// <summary>
    /// Base controller inherited by all other controllers
    /// </summary>
    public abstract partial class BaseController : Controller
    {
        /// <summary>
        /// Field for the UserState
        /// </summary>
        private UserState userState = new UserState();

        /// <summary>
        /// Field for the CurrentAccount property
        /// </summary>
        private Account currentAccount;

        /// <summary>
        /// Gets or sets the account service.
        /// </summary>
        /// <value>
        /// The account service.
        /// </value>
        [Inject]
        public IAccountService AccountService { get; set; }

        /// <summary>
        /// Gets the current account.
        /// </summary>
        public Account CurrentAccount
        {
            get
            {
                if (this.currentAccount == null)
                {
                    if (this.userState != null && this.userState.PrivateGuid != null)
                    {
                        this.currentAccount = this.AccountService.GetByPrivateGuid(this.userState.PrivateGuid);
                    }
                }

                return this.currentAccount;
            }
        }

        /// <summary>
        /// Initializes data that might not be available when the constructor is called.
        /// </summary>
        /// <param name="requestContext">The HTTP context and route data.</param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            this.userState = new UserState();
            if (this.User.Identity != null && this.User.Identity is FormsIdentity)
            {
                this.userState.FromString(((FormsIdentity)this.User.Identity).Ticket.UserData);
            }

            this.ViewData["UserState"] = this.userState;
        }
    }
}

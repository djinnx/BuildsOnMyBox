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
    using BOMB.Web.ViewModels.Account;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
    using DotNetOpenAuth.OpenId.RelyingParty;

    /// <summary>
    /// Account Controller
    /// </summary>
    public partial class AccountController : BaseController
    {
        /// <summary>
        /// Field for the Account Service
        /// </summary>
        private IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
            : base(new AccountService())
        {
            this.accountService = new AccountService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        public AccountController(IAccountService accountService)
            : base(accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Logon Action.
        /// </summary>
        /// <returns>Logon View</returns>
        public virtual ActionResult LogOn()
        {
            LogOn model = new LogOn();
            var openid = new OpenIdRelyingParty();
            IAuthenticationResponse response = openid.GetResponse();

            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var email = string.Empty;
                        var claimsResponse = response.GetExtension<ClaimsResponse>();
                        if (claimsResponse != null)
                        {
                            email = claimsResponse.Email;
                        }

                        if (!string.IsNullOrEmpty(email))
                        {
                            var guid = this.accountService.NewAccountStep1(response.ClaimedIdentifier, email);

                            if (this.accountService.NeedsAdditionInformation(guid))
                            {
                                return this.RedirectToAction(this.Actions.LogOnStep2(guid, email));
                            }
                            else
                            {
                                Account a = this.accountService.Get(guid);
                                this.IssueAuthTicket(new UserState() { PrivateGuid = a.PrivateGuid, EmailAddress = a.EmailAddress, DisplayName = a.DisplayName }, true);
                            }

                            return this.RedirectToAction(MVC.Home.Index());
                        }
                        else
                        {
                            model.ShowNoEmailError = true;
                        }

                        break;
                    case AuthenticationStatus.Canceled:
                        model.ShowCancelledError = true;
                        break;
                    case AuthenticationStatus.Failed:
                        model.ShowFailedError = true;
                        break;
                }
            }

            // fall through to show login view, not a return from the openid provider.
            return this.View(model);
        }

        /// <summary>
        /// Logon Action after a Post
        /// </summary>
        /// <param name="openid_identifier">The openid_identifier.</param>
        /// <returns>Logon View</returns>
        [HttpPost]
        public virtual ActionResult LogOn(string openid_identifier)
        {
            if (!Identifier.IsValid(openid_identifier))
            {
                ModelState.AddModelError("openid_identifier", "The specified login identifier is invalid");
                return this.View();
            }
            else
            {
                var openid = new OpenIdRelyingParty();
                IAuthenticationRequest request = openid.CreateRequest(
                    Identifier.Parse(openid_identifier));

                // Require some additional data
                request.AddExtension(new ClaimsRequest
                {
                    Email = DemandLevel.Require
                });

                return request.RedirectingResponse.AsActionResult();
            }
        }

        /// <summary>
        /// Logon user step 2.
        /// </summary>
        /// <param name="userToken">The user token.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>LogOn Step2 View</returns>
        public virtual ActionResult LogOnStep2(Guid userToken, string emailAddress)
        {
            Step2 model = new Step2()
            {
                PrivateGuid = userToken,
                EmailAddress = emailAddress,
                DisplayName = string.Empty,
            };

            return this.View(model);
        }

        /// <summary>
        /// Logon user step 2 Post.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>LogOn Step2 View</returns>
        [HttpPost]
        public virtual ActionResult LogOnStep2(Step2 model)
        {
            if (ModelState.IsValid)
            {
                var success = this.accountService.NewAccountStep2(model.PrivateGuid, model.EmailAddress, model.DisplayName);

                if (success)
                {
                    this.IssueAuthTicket(new UserState() { PrivateGuid = model.PrivateGuid, EmailAddress = model.EmailAddress, DisplayName = model.DisplayName }, true);
                    return this.RedirectToAction(this.Actions.FirstTimeLoggingIn());
                }

                ModelState.AddModelError(string.Empty, "Error");
            }

            return this.View(model);
        }

        /// <summary>
        /// Firsts time logging in action.
        /// </summary>
        /// <returns>First time logging in view</returns>
        public virtual ActionResult FirstTimeLoggingIn()
        {
            return this.View();
        }

        /// <summary>
        /// Logs the user off.
        /// </summary>
        /// <param name="redirectTo">The redirect to.</param>
        /// <returns>
        /// Redirect to url or home index
        /// </returns>
        public virtual ActionResult LogOff(string redirectTo)
        {
            FormsAuthentication.SignOut();

            if (string.IsNullOrEmpty(redirectTo))
            {
                return new RedirectResult(redirectTo);
            }

            return this.RedirectToAction(MVC.Home.Index());
        }

        /// <summary>
        /// Issues the auth ticket.
        /// </summary>
        /// <param name="userState">State of the user.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        private void IssueAuthTicket(UserState userState, bool rememberMe)
        {
            // create auth ticket
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userState.DisplayName, DateTime.Now, DateTime.Now.AddYears(1), rememberMe, userState.ToString());

            // encrypt ticket
            string ticketString = FormsAuthentication.Encrypt(ticket);

            // create cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketString);
            if (rememberMe)
            {
                // set expiration
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            // add cokie to users machine
            HttpContext.Response.Cookies.Add(cookie);
        }
    }
}

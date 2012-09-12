namespace BOMB.Web.ViewModels.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// LogOn Step 2 View Model
    /// </summary>
    public class Step2
    {
        /// <summary>
        /// Gets or sets the private GUID.
        /// </summary>
        /// <value>
        /// The private GUID.
        /// </value>
        public Guid PrivateGuid { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        [Required(ErrorMessage = "Display Name is required.")]
        [StringLength(100)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
    }
}
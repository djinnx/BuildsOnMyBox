namespace BOMB.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a user
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the public GUID.
        /// </summary>
        /// <value>
        /// The public GUID.
        /// </value>
        public Guid PublicGuid { get; set; }

        /// <summary>
        /// Gets or sets the private GUID.
        /// </summary>
        /// <value>
        /// The private GUID.
        /// </value>
        public Guid PrivateGuid { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }
    }
}

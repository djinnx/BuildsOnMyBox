namespace BOMB.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Account class, stores information about the account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

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
        /// Gets or sets the claimed identifier.
        /// </summary>
        /// <value>
        /// The claimed identifier.
        /// </value>
        [Required]
        [MaxLength(1000)]
        public string ClaimedIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Required]
        [MaxLength(250)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Converts this to Domain.Account
        /// </summary>
        /// <returns>Domain.Account object</returns>
        public BOMB.Domain.Account ToDomainAccount()
        {
            return new Domain.Account()
            {
                PrivateGuid = this.PrivateGuid,
                PublicGuid = this.PublicGuid,
                DisplayName = this.DisplayName,
                EmailAddress = this.EmailAddress,
            };
        }
    }
}

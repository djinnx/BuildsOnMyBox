namespace BOMB.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The UserState object
    /// </summary>
    public class UserState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserState"/> class.
        /// </summary>
        public UserState()
        {
            this.Valid = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserState"/> is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        public bool Valid { get; set; }

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

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}||{1}||{2}", this.PrivateGuid, this.DisplayName, this.EmailAddress);
        }

        /// <summary>
        /// Rehydrates the object based off double pipe delimited string.
        /// </summary>
        /// <param name="input">The input.</param>
        public void FromString(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string[] seperators = new string[] { "||" };
                var x = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                if (x.Count() == 3)
                {
                    this.PrivateGuid = new Guid(x[0]);
                    this.DisplayName = x[1];
                    this.EmailAddress = x[2];
                    this.Valid = true;
                }
            }
        }
    }
}
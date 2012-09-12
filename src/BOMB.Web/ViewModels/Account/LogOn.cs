namespace BOMB.Web.ViewModels.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// LogOn View Model
    /// </summary>
    public class LogOn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogOn"/> class.
        /// </summary>
        public LogOn()
        {
            this.ShowNoEmailError = false;
            this.ShowFailedError = false;
            this.ShowCancelledError = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show no email error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show no email error]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowNoEmailError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show failed error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show failed error]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowFailedError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show cancelled error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show cancelled error]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowCancelledError { get; set; }
    }
}
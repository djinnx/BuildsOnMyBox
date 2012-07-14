// -----------------------------------------------------------------------
// Grabbed from the MVCContrib project
// -----------------------------------------------------------------------

namespace BOMB.Web.Tests.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Exception that is thrown when a ActionResult assertion fails.
    /// </summary>
    public class ActionResultAssertionException : Exception
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ActionResultAssertionException"/> class.
        /// </summary>
        /// <param name="message">Message thrown in the exception.</param>
        public ActionResultAssertionException(string message)
            : base(message)
        {

        }
    }
}

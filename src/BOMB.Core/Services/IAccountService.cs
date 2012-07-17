namespace BOMB.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BOMB.Domain;

    /// <summary>
    /// Middle tier for all Account work
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Accounts the exists.
        /// </summary>
        /// <param name="publicGuid">The public GUID.</param>
        /// <returns>Boolean representing if the acocunt exitsts</returns>
        bool AccountExists(Guid publicGuid);

        /// <summary>
        /// Gets the specified account by private GUID.
        /// </summary>
        /// <param name="privateGuid">The private GUID.</param>
        /// <returns>An Account</returns>
        Account Get(Guid privateGuid);

        /// <summary>
        /// Setup a new account step 1
        /// </summary>
        /// <param name="claimedIdentifier">The claimed identifier.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>Private Guid</returns>
        Guid NewAccountStep1(string claimedIdentifier, string emailAddress);

        /// <summary>
        /// Setup a new account step 2
        /// </summary>
        /// <param name="privateGuid">The private GUID.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns>
        /// True if successful, False if failed
        /// </returns>
        bool NewAccountStep2(Guid privateGuid, string emailAddress, string displayName);

        /// <summary>
        /// Does the user need additional information
        /// </summary>
        /// <param name="privateGuid">The private GUID.</param>
        /// <returns>True if the user needs additional information</returns>
        bool NeedsAdditionInformation(Guid privateGuid);
    }
}

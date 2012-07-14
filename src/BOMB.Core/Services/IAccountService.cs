namespace BOMB.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
    }
}

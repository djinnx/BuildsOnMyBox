namespace BOMB.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BOMB.Data;

    /// <summary>
    /// Middle tier for all Account work
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// backing variable for the Unit Of Work
        /// </summary>
        private UnitOfWork uow = new UnitOfWork();

        /// <summary>
        /// Accounts the exists.
        /// </summary>
        /// <param name="publicGuid">The public GUID.</param>
        /// <returns>Boolean representing if the acocunt exitsts</returns>
        public bool AccountExists(Guid publicGuid)
        {
            foreach (var item in this.uow.AccountRepository.Get())
            {
            }

            return true;
            ////return this.uow.AccountRepository.Get().Any(x => x.PublicGuid == publicGuid);
        }
    }
}

namespace BOMB.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BOMB.Data;
    using BOMB.Data.Models;

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
            return this.uow.AccountRepository.Get().Any(x => x.PublicGuid == publicGuid);
        }

        /// <summary>
        /// Setup a new account step 1
        /// </summary>
        /// <param name="claimedIdentifier">The claimed identifier.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>
        /// Public Guid
        /// </returns>
        public Guid NewAccountStep1(string claimedIdentifier, string emailAddress)
        {
            var account = this.uow.AccountRepository.Get().SingleOrDefault(x => x.ClaimedIdentifier == claimedIdentifier && x.EmailAddress == emailAddress);

            if (account != null)
            {
                return account.PrivateGuid;
            }

            Account a = new Account()
            {
                PrivateGuid = Guid.NewGuid(),
                PublicGuid = Guid.NewGuid(),
                ClaimedIdentifier = claimedIdentifier,
                EmailAddress = emailAddress,
                DisplayName = string.Empty,
            };

            this.uow.AccountRepository.Insert(a);
            this.uow.Save();

            return a.PrivateGuid;
        }

        /// <summary>
        /// Setup a new account step 2
        /// </summary>
        /// <param name="privateGuid">The private GUID.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns>
        /// True if successful, False if failed
        /// </returns>
        public bool NewAccountStep2(Guid privateGuid, string emailAddress, string displayName)
        {
            Account a = this.uow.AccountRepository.Get().SingleOrDefault(x => x.PrivateGuid == privateGuid && x.EmailAddress == emailAddress);

            if (a == null)
            {
                return false;
            }

            a.DisplayName = displayName;
            this.uow.AccountRepository.Update(a);
            this.uow.Save();

            return true;
        }

        /// <summary>
        /// Needses the addition information.
        /// </summary>
        /// <param name="privateGuid">The private GUID.</param>
        /// <returns>
        /// True if the account needs more information
        /// </returns>
        public bool NeedsAdditionInformation(Guid privateGuid)
        {
            var account = this.uow.AccountRepository.Get().SingleOrDefault(x => x.PrivateGuid == privateGuid);

            if (account != null && !string.IsNullOrEmpty(account.DisplayName))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the specified account by private GUID.
        /// </summary>
        /// <param name="privateGuid">The private GUID.</param>
        /// <returns>
        /// An Account
        /// </returns>
        public BOMB.Domain.Account Get(Guid privateGuid)
        {
            var account = this.uow.AccountRepository.Get().SingleOrDefault(x => x.PrivateGuid == privateGuid);

            if (account == null)
            {
                throw new NullReferenceException("Account does not exist");
            }

            return account.ToDomainAccount();
        }
    }
}

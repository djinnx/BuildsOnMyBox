namespace BOMB.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using BOMB.Data.Models;

    /// <summary>
    /// Manages the work between different dbsets
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// used to determine if the item is being disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// the context of the db
        /// </summary>
        private BombContext context = new BombContext();

        /// <summary>
        /// Account Repository backing variable
        /// </summary>
        private GenericRepository<Account> accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public BombContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Gets the account repository.
        /// </summary>
        public GenericRepository<Account> AccountRepository
        {
            get
            {
                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<Account>(this.context);
                }

                return this.accountRepository;
            }
        }

        /// <summary>
        /// Runs the data migrations.
        /// </summary>
        public void RunDataMigrations()
        {
            var migrator = new DbMigrator(new Migrations.Configuration());
            migrator.Update();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}

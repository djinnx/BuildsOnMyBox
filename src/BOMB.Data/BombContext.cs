namespace BOMB.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Text;
    using BOMB.Data.Models;

    /// <summary>
    /// EF data context
    /// </summary>
    public class BombContext : DbContext
    {
        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Validates the on save.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void ValidateOnSave(bool value)
        {
            Configuration.ValidateOnSaveEnabled = value;
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

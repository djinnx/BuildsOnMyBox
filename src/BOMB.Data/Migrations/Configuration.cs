namespace BOMB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Migrations Configuration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<BOMB.Data.BombContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(BOMB.Data.BombContext context)
        {
            ////  This method will be called after migrating to the latest version.
            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////
        }
    }
}

namespace BOMB.Data.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Add account private guid migration
    /// </summary>
    public partial class AccountPrivateGuid : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("Account", "PrivateGuid", c => c.Guid(nullable: false));
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("Account", "PrivateGuid");
        }
    }
}

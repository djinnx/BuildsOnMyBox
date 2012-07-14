namespace BOMB.Data.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for Account Table
    /// </summary>
    public partial class Account : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "Account",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PublicGuid = c.Guid(nullable: false),
                    ClaimedIdentifier = c.String(nullable: false, maxLength: 1000),
                    EmailAddress = c.String(nullable: false, maxLength: 250),
                    DisplayName = c.String(nullable: false, maxLength: 100)
                })
                .PrimaryKey(t => t.Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropTable("Account");
        }
    }
}
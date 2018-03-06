namespace BoardGameShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedMigrationTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "MigrationTest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "MigrationTest", c => c.Boolean(nullable: false));
        }
    }
}

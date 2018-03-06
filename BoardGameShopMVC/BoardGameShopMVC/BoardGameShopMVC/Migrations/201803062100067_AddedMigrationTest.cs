namespace BoardGameShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMigrationTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "MigrationTest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "MigrationTest");
        }
    }
}

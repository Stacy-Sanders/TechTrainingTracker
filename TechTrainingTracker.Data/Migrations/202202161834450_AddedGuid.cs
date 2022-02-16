namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "AdminID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "AdminID");
        }
    }
}

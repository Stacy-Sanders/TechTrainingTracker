namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certification", "AdminID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Certification", "AdminID");
        }
    }
}

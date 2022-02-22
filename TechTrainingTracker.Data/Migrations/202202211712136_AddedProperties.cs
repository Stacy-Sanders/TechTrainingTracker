namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "CompanyWebsite", c => c.String());
            AddColumn("dbo.User", "PortfolioURL", c => c.String());
            AddColumn("dbo.Training", "CourseWebsite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Training", "CourseWebsite");
            DropColumn("dbo.User", "PortfolioURL");
            DropColumn("dbo.Company", "CompanyWebsite");
        }
    }
}

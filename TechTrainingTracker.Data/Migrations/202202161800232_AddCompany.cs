namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "HasApp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Company", "HasAccreditedCourses", c => c.Boolean(nullable: false));
            AddColumn("dbo.Company", "Accreditation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Accreditation");
            DropColumn("dbo.Company", "HasAccreditedCourses");
            DropColumn("dbo.Company", "HasApp");
        }
    }
}

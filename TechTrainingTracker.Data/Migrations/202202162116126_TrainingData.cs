namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainingData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skill", "AdminId", c => c.Guid(nullable: false));
            AddColumn("dbo.Skill", "Language", c => c.String());
            AddColumn("dbo.Skill", "SkillLevel", c => c.String());
            AddColumn("dbo.Training", "AdminID", c => c.Guid(nullable: false));
            AddColumn("dbo.Training", "CourseName", c => c.String());
            AddColumn("dbo.Training", "Language", c => c.String());
            AddColumn("dbo.Training", "DifficultyLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Training", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Training", "LearningLocation", c => c.Int(nullable: false));
            AddColumn("dbo.Training", "LearningMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Training", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Training", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.User", "AdminID", c => c.Guid(nullable: false));
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.User", "Address", c => c.String());
            AddColumn("dbo.User", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.User", "EmailAddress", c => c.String(nullable: false));
            AddColumn("dbo.User", "CertificationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Training", "CompanyID");
            CreateIndex("dbo.User", "CertificationID");
            AddForeignKey("dbo.Training", "CompanyID", "dbo.Company", "CompanyID", cascadeDelete: true);
            AddForeignKey("dbo.User", "CertificationID", "dbo.Certification", "CertificationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CertificationID", "dbo.Certification");
            DropForeignKey("dbo.Training", "CompanyID", "dbo.Company");
            DropIndex("dbo.User", new[] { "CertificationID" });
            DropIndex("dbo.Training", new[] { "CompanyID" });
            DropColumn("dbo.User", "CertificationID");
            DropColumn("dbo.User", "EmailAddress");
            DropColumn("dbo.User", "PhoneNumber");
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.User", "AdminID");
            DropColumn("dbo.Training", "CompanyID");
            DropColumn("dbo.Training", "Duration");
            DropColumn("dbo.Training", "LearningMethod");
            DropColumn("dbo.Training", "LearningLocation");
            DropColumn("dbo.Training", "Cost");
            DropColumn("dbo.Training", "DifficultyLevel");
            DropColumn("dbo.Training", "Language");
            DropColumn("dbo.Training", "CourseName");
            DropColumn("dbo.Training", "AdminID");
            DropColumn("dbo.Skill", "SkillLevel");
            DropColumn("dbo.Skill", "Language");
            DropColumn("dbo.Skill", "AdminId");
        }
    }
}

namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certification",
                c => new
                    {
                        CertificationID = c.Int(nullable: false, identity: true),
                        AdminID = c.Guid(nullable: false),
                        UserID = c.Int(nullable: false),
                        CertificationName = c.String(nullable: false),
                        HasExam = c.Boolean(nullable: false),
                        ExamFee = c.Double(nullable: false),
                        IssueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ExpireDate = c.DateTimeOffset(precision: 7),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CertificationID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        AdminID = c.Guid(nullable: false),
                        CompanyName = c.String(nullable: false),
                        HasFreeCourses = c.Boolean(nullable: false),
                        HasPaidSubscription = c.Boolean(nullable: false),
                        HasApp = c.Boolean(nullable: false),
                        HasAccreditedCourses = c.Boolean(nullable: false),
                        Accreditation = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        AdminID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        KnownLanguages = c.Int(nullable: false),
                        Language = c.String(),
                        SkillLevel = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.SkillID);
            
            CreateTable(
                "dbo.Training",
                c => new
                    {
                        TrainingID = c.Int(nullable: false, identity: true),
                        AdminID = c.Guid(nullable: false),
                        CourseName = c.String(),
                        UserID = c.Int(nullable: false),
                        Language = c.String(),
                        DifficultyLevel = c.String(),
                        IsSubcriptionRequired = c.Boolean(nullable: false),
                        SubscriptionCost = c.Double(nullable: false),
                        IsFree = c.Boolean(nullable: false),
                        CourseCost = c.Double(nullable: false),
                        LearningLocation = c.String(),
                        LearningMethod = c.String(),
                        Duration = c.String(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Training", "UserID", "dbo.User");
            DropForeignKey("dbo.Training", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Certification", "UserID", "dbo.User");
            DropForeignKey("dbo.Certification", "CompanyID", "dbo.Company");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Training", new[] { "CompanyID" });
            DropIndex("dbo.Training", new[] { "UserID" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Certification", new[] { "CompanyID" });
            DropIndex("dbo.Certification", new[] { "UserID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Training");
            DropTable("dbo.Skill");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.User");
            DropTable("dbo.Company");
            DropTable("dbo.Certification");
        }
    }
}

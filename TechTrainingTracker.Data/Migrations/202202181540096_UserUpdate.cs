namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "StreetAddress", c => c.String(nullable: false));
            AddColumn("dbo.User", "StreetAddress2", c => c.String());
            AddColumn("dbo.User", "City", c => c.String(nullable: false));
            AddColumn("dbo.User", "State", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.User", "ZipCode", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Skill", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Skill", "isTopTenDesirability", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Skill", "SkillLevel", c => c.String(nullable: false));
            CreateIndex("dbo.Skill", "UserID");
            AddForeignKey("dbo.Skill", "UserID", "dbo.User", "UserID", cascadeDelete: true);
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.Skill", "KnownLanguages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skill", "KnownLanguages", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Address", c => c.String());
            DropForeignKey("dbo.Skill", "UserID", "dbo.User");
            DropIndex("dbo.Skill", new[] { "UserID" });
            AlterColumn("dbo.Skill", "SkillLevel", c => c.String());
            DropColumn("dbo.Skill", "isTopTenDesirability");
            DropColumn("dbo.Skill", "UserID");
            DropColumn("dbo.User", "ZipCode");
            DropColumn("dbo.User", "State");
            DropColumn("dbo.User", "City");
            DropColumn("dbo.User", "StreetAddress2");
            DropColumn("dbo.User", "StreetAddress");
        }
    }
}

namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Certification", "IssueDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Certification", "ExpireDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Certification", "ExpireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Certification", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}

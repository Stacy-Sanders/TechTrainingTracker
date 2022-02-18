namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarProgressUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Training", "IsStarred", c => c.Boolean(nullable: false));
            AddColumn("dbo.Training", "InProgress", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Training", "InProgress");
            DropColumn("dbo.Training", "IsStarred");
        }
    }
}

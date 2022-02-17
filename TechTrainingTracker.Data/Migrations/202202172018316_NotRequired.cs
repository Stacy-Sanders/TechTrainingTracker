namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "SubscriptionCost", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "SubscriptionCost", c => c.Double(nullable: false));
        }
    }
}

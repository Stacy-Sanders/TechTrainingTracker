namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "SubscriptionCost", c => c.Double(nullable: false));
            AddColumn("dbo.Company", "IsSubcriptionRequired", c => c.Boolean(nullable: false));
            DropColumn("dbo.Training", "SubscriptionCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Training", "SubscriptionCost", c => c.Double(nullable: false));
            DropColumn("dbo.Company", "IsSubcriptionRequired");
            DropColumn("dbo.Company", "SubscriptionCost");
        }
    }
}

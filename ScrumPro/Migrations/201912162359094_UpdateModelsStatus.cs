namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IssueStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Stories", "IssueStatus", c => c.Int(nullable: false));
            AddColumn("dbo.StoryTasks", "IssueStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoryTasks", "IssueStatus");
            DropColumn("dbo.Stories", "IssueStatus");
            DropColumn("dbo.Projects", "IssueStatus");
        }
    }
}

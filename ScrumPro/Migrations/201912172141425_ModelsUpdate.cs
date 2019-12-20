namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Priorities", c => c.Int(nullable: false));
            AddColumn("dbo.Stories", "SoftwareStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Priorities", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "SoftwareStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Sprints", "Priorities", c => c.Int(nullable: false));
            AddColumn("dbo.Sprints", "SoftwareStatus", c => c.Int(nullable: false));
            AddColumn("dbo.StoryTasks", "Priorities", c => c.Int(nullable: false));
            AddColumn("dbo.StoryTasks", "SoftwareStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoryTasks", "SoftwareStatus");
            DropColumn("dbo.StoryTasks", "Priorities");
            DropColumn("dbo.Sprints", "SoftwareStatus");
            DropColumn("dbo.Sprints", "Priorities");
            DropColumn("dbo.Projects", "SoftwareStatus");
            DropColumn("dbo.Projects", "Priorities");
            DropColumn("dbo.Stories", "SoftwareStatus");
            DropColumn("dbo.Stories", "Priorities");
        }
    }
}

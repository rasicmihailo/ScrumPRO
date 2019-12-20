namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "StoryTaskId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Comments", "StoryTaskId");
            AddForeignKey("dbo.Comments", "StoryTaskId", "dbo.StoryTasks", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StoryTaskId", "dbo.StoryTasks");
            DropIndex("dbo.Comments", new[] { "StoryTaskId" });
            DropColumn("dbo.Comments", "StoryTaskId");
        }
    }
}

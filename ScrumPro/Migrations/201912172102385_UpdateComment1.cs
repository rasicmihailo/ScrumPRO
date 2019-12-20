namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "StoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Comments", "StoryId");
            AddForeignKey("dbo.Comments", "StoryId", "dbo.Stories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StoryId", "dbo.Stories");
            DropIndex("dbo.Comments", new[] { "StoryId" });
            DropColumn("dbo.Comments", "StoryId");
        }
    }
}

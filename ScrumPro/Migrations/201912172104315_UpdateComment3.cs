namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserSprints", newName: "SprintApplicationUsers");
            RenameTable(name: "dbo.StoryApplicationUsers", newName: "ApplicationUserStories");
            RenameTable(name: "dbo.DailyReportStories", newName: "StoryDailyReports");
            DropPrimaryKey("dbo.SprintApplicationUsers");
            DropPrimaryKey("dbo.ApplicationUserStories");
            DropPrimaryKey("dbo.StoryDailyReports");
            AddColumn("dbo.Comments", "DailyReportId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SprintApplicationUsers", new[] { "Sprint_Id", "ApplicationUser_Id" });
            AddPrimaryKey("dbo.ApplicationUserStories", new[] { "ApplicationUser_Id", "Story_Id" });
            AddPrimaryKey("dbo.StoryDailyReports", new[] { "Story_Id", "DailyReport_Id" });
            CreateIndex("dbo.Comments", "DailyReportId");
            AddForeignKey("dbo.Comments", "DailyReportId", "dbo.DailyReports", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "DailyReportId", "dbo.DailyReports");
            DropIndex("dbo.Comments", new[] { "DailyReportId" });
            DropPrimaryKey("dbo.StoryDailyReports");
            DropPrimaryKey("dbo.ApplicationUserStories");
            DropPrimaryKey("dbo.SprintApplicationUsers");
            DropColumn("dbo.Comments", "DailyReportId");
            AddPrimaryKey("dbo.StoryDailyReports", new[] { "DailyReport_Id", "Story_Id" });
            AddPrimaryKey("dbo.ApplicationUserStories", new[] { "Story_Id", "ApplicationUser_Id" });
            AddPrimaryKey("dbo.SprintApplicationUsers", new[] { "ApplicationUser_Id", "Sprint_Id" });
            RenameTable(name: "dbo.StoryDailyReports", newName: "DailyReportStories");
            RenameTable(name: "dbo.ApplicationUserStories", newName: "StoryApplicationUsers");
            RenameTable(name: "dbo.SprintApplicationUsers", newName: "ApplicationUserSprints");
        }
    }
}

namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stories", "DailyReport_Id", "dbo.DailyReports");
            DropForeignKey("dbo.StoryTasks", "DailyReport_Id", "dbo.DailyReports");
            DropIndex("dbo.Stories", new[] { "DailyReport_Id" });
            DropIndex("dbo.StoryTasks", new[] { "DailyReport_Id" });
            CreateTable(
                "dbo.DailyReportStories",
                c => new
                    {
                        DailyReport_Id = c.Int(nullable: false),
                        Story_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.DailyReport_Id, t.Story_Id })
                .ForeignKey("dbo.DailyReports", t => t.DailyReport_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.Story_Id, cascadeDelete: true)
                .Index(t => t.DailyReport_Id)
                .Index(t => t.Story_Id);
            
            CreateTable(
                "dbo.StoryTaskDailyReports",
                c => new
                    {
                        StoryTask_Id = c.Byte(nullable: false),
                        DailyReport_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoryTask_Id, t.DailyReport_Id })
                .ForeignKey("dbo.StoryTasks", t => t.StoryTask_Id, cascadeDelete: true)
                .ForeignKey("dbo.DailyReports", t => t.DailyReport_Id, cascadeDelete: true)
                .Index(t => t.StoryTask_Id)
                .Index(t => t.DailyReport_Id);
            
            DropColumn("dbo.Stories", "DailyReport_Id");
            DropColumn("dbo.StoryTasks", "DailyReport_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoryTasks", "DailyReport_Id", c => c.Int());
            AddColumn("dbo.Stories", "DailyReport_Id", c => c.Int());
            DropForeignKey("dbo.StoryTaskDailyReports", "DailyReport_Id", "dbo.DailyReports");
            DropForeignKey("dbo.StoryTaskDailyReports", "StoryTask_Id", "dbo.StoryTasks");
            DropForeignKey("dbo.DailyReportStories", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.DailyReportStories", "DailyReport_Id", "dbo.DailyReports");
            DropIndex("dbo.StoryTaskDailyReports", new[] { "DailyReport_Id" });
            DropIndex("dbo.StoryTaskDailyReports", new[] { "StoryTask_Id" });
            DropIndex("dbo.DailyReportStories", new[] { "Story_Id" });
            DropIndex("dbo.DailyReportStories", new[] { "DailyReport_Id" });
            DropTable("dbo.StoryTaskDailyReports");
            DropTable("dbo.DailyReportStories");
            CreateIndex("dbo.StoryTasks", "DailyReport_Id");
            CreateIndex("dbo.Stories", "DailyReport_Id");
            AddForeignKey("dbo.StoryTasks", "DailyReport_Id", "dbo.DailyReports", "Id");
            AddForeignKey("dbo.Stories", "DailyReport_Id", "dbo.DailyReports", "Id");
        }
    }
}

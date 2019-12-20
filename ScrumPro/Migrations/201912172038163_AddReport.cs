namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfReport = c.DateTime(nullable: false),
                        Name = c.String(),
                        UserId = c.Byte(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Stories", "DailyReport_Id", c => c.Int());
            AddColumn("dbo.StoryTasks", "DailyReport_Id", c => c.Int());
            CreateIndex("dbo.Stories", "DailyReport_Id");
            CreateIndex("dbo.StoryTasks", "DailyReport_Id");
            AddForeignKey("dbo.Stories", "DailyReport_Id", "dbo.DailyReports", "Id");
            AddForeignKey("dbo.StoryTasks", "DailyReport_Id", "dbo.DailyReports", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyReports", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StoryTasks", "DailyReport_Id", "dbo.DailyReports");
            DropForeignKey("dbo.Stories", "DailyReport_Id", "dbo.DailyReports");
            DropIndex("dbo.DailyReports", new[] { "User_Id" });
            DropIndex("dbo.StoryTasks", new[] { "DailyReport_Id" });
            DropIndex("dbo.Stories", new[] { "DailyReport_Id" });
            DropColumn("dbo.StoryTasks", "DailyReport_Id");
            DropColumn("dbo.Stories", "DailyReport_Id");
            DropTable("dbo.DailyReports");
        }
    }
}

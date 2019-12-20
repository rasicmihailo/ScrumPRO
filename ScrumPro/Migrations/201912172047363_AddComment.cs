namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserCompanies", newName: "CompanyApplicationUsers");
            DropIndex("dbo.DailyReports", new[] { "User_Id" });
            DropColumn("dbo.DailyReports", "UserId");
            RenameColumn(table: "dbo.DailyReports", name: "User_Id", newName: "UserId");
            DropPrimaryKey("dbo.CompanyApplicationUsers");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Text = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.DailyReports", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.CompanyApplicationUsers", new[] { "Company_Id", "ApplicationUser_Id" });
            CreateIndex("dbo.DailyReports", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DailyReports", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropPrimaryKey("dbo.CompanyApplicationUsers");
            AlterColumn("dbo.DailyReports", "UserId", c => c.Byte(nullable: false));
            DropTable("dbo.Comments");
            AddPrimaryKey("dbo.CompanyApplicationUsers", new[] { "ApplicationUser_Id", "Company_Id" });
            RenameColumn(table: "dbo.DailyReports", name: "UserId", newName: "User_Id");
            AddColumn("dbo.DailyReports", "UserId", c => c.Byte(nullable: false));
            CreateIndex("dbo.DailyReports", "User_Id");
            RenameTable(name: "dbo.CompanyApplicationUsers", newName: "ApplicationUserCompanies");
        }
    }
}

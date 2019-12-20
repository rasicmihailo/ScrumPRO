namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CompanyApplicationUsers", newName: "ApplicationUserCompanies");
            RenameTable(name: "dbo.ProjectApplicationUsers", newName: "ApplicationUserProjects");
            RenameTable(name: "dbo.SprintApplicationUsers", newName: "ApplicationUserSprints");
            DropPrimaryKey("dbo.ApplicationUserCompanies");
            DropPrimaryKey("dbo.ApplicationUserProjects");
            DropPrimaryKey("dbo.ApplicationUserSprints");
            AddColumn("dbo.Comments", "SprintId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.ApplicationUserCompanies", new[] { "ApplicationUser_Id", "Company_Id" });
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "ApplicationUser_Id", "Project_Id" });
            AddPrimaryKey("dbo.ApplicationUserSprints", new[] { "ApplicationUser_Id", "Sprint_Id" });
            CreateIndex("dbo.Comments", "SprintId");
            AddForeignKey("dbo.Comments", "SprintId", "dbo.Sprints", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "SprintId", "dbo.Sprints");
            DropIndex("dbo.Comments", new[] { "SprintId" });
            DropPrimaryKey("dbo.ApplicationUserSprints");
            DropPrimaryKey("dbo.ApplicationUserProjects");
            DropPrimaryKey("dbo.ApplicationUserCompanies");
            DropColumn("dbo.Comments", "SprintId");
            AddPrimaryKey("dbo.ApplicationUserSprints", new[] { "Sprint_Id", "ApplicationUser_Id" });
            AddPrimaryKey("dbo.ApplicationUserProjects", new[] { "Project_Id", "ApplicationUser_Id" });
            AddPrimaryKey("dbo.ApplicationUserCompanies", new[] { "Company_Id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserSprints", newName: "SprintApplicationUsers");
            RenameTable(name: "dbo.ApplicationUserProjects", newName: "ProjectApplicationUsers");
            RenameTable(name: "dbo.ApplicationUserCompanies", newName: "CompanyApplicationUsers");
        }
    }
}

namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigUpdates : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Stories", name: "ProjectId", newName: "SprintId");
            RenameIndex(table: "dbo.Stories", name: "IX_ProjectId", newName: "IX_SprintId");
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ProjectId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.SprintApplicationUsers",
                c => new
                    {
                        Sprint_Id = c.Byte(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Sprint_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Sprints", t => t.Sprint_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Sprint_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AlterColumn("dbo.Stories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SprintApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SprintApplicationUsers", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.Sprints", "ProjectId", "dbo.Projects");
            DropIndex("dbo.SprintApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SprintApplicationUsers", new[] { "Sprint_Id" });
            DropIndex("dbo.Sprints", new[] { "ProjectId" });
            AlterColumn("dbo.Stories", "Name", c => c.String(nullable: false));
            DropTable("dbo.SprintApplicationUsers");
            DropTable("dbo.Sprints");
            RenameIndex(table: "dbo.Stories", name: "IX_SprintId", newName: "IX_ProjectId");
            RenameColumn(table: "dbo.Stories", name: "SprintId", newName: "ProjectId");
        }
    }
}

namespace ScrumPRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Text = c.String(),
                        UserId = c.String(maxLength: 128),
                        SprintId = c.Byte(nullable: false),
                        StoryId = c.Byte(nullable: false),
                        StoryTaskId = c.Byte(nullable: false),
                        DailyReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DailyReports", t => t.DailyReportId, cascadeDelete: true)
                .ForeignKey("dbo.Sprints", t => t.SprintId, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.StoryTasks", t => t.StoryTaskId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SprintId)
                .Index(t => t.StoryId)
                .Index(t => t.StoryTaskId)
                .Index(t => t.DailyReportId);
            
            CreateTable(
                "dbo.DailyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfReport = c.DateTime(nullable: false),
                        Name = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Priorities = c.Int(nullable: false),
                        SoftwareStatus = c.Int(nullable: false),
                        SprintId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sprints", t => t.SprintId, cascadeDelete: false)
                .Index(t => t.SprintId);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Priorities = c.Int(nullable: false),
                        SoftwareStatus = c.Int(nullable: false),
                        ProjectId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Priorities = c.Int(nullable: false),
                        SoftwareStatus = c.Int(nullable: false),
                        CompanyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PreferredName = c.String(),
                        Statistic = c.Double(nullable: false),
                        TotalNumberOfTasks = c.Int(nullable: false),
                        NumberOfTasksDoneCorectly = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StoryTasks",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Priorities = c.Int(nullable: false),
                        SoftwareStatus = c.Int(nullable: false),
                        StoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: false)
                .Index(t => t.StoryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.DailyReportOfStory",
                c => new
                    {
                        StoryId = c.Byte(nullable: false),
                        DailyReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoryId, t.DailyReportId })
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.DailyReports", t => t.DailyReportId, cascadeDelete: true)
                .Index(t => t.StoryId)
                .Index(t => t.DailyReportId);
            
            CreateTable(
                "dbo.CompanyUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CompanyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CompanyId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProjectId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.SprintEmployees",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        SprintId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.SprintId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Sprints", t => t.SprintId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SprintId);
            
            CreateTable(
                "dbo.TaskEmplyees",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        StoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.StoryId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.StoryId);
            
            CreateTable(
                "dbo.DailyReportOfStoryTasks",
                c => new
                    {
                        StoryTaskId = c.Byte(nullable: false),
                        DailyReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoryTaskId, t.DailyReportId })
                .ForeignKey("dbo.StoryTasks", t => t.StoryTaskId, cascadeDelete: true)
                .ForeignKey("dbo.DailyReports", t => t.DailyReportId, cascadeDelete: true)
                .Index(t => t.StoryTaskId)
                .Index(t => t.DailyReportId);
            
            CreateTable(
                "dbo.StoryTaskEmployees",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        StoryTaskId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.StoryTaskId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.StoryTasks", t => t.StoryTaskId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.StoryTaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "StoryTaskId", "dbo.StoryTasks");
            DropForeignKey("dbo.Comments", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Comments", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.Comments", "DailyReportId", "dbo.DailyReports");
            DropForeignKey("dbo.DailyReports", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Stories", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.Sprints", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.StoryTaskEmployees", "StoryTaskId", "dbo.StoryTasks");
            DropForeignKey("dbo.StoryTaskEmployees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StoryTasks", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.DailyReportOfStoryTasks", "DailyReportId", "dbo.DailyReports");
            DropForeignKey("dbo.DailyReportOfStoryTasks", "StoryTaskId", "dbo.StoryTasks");
            DropForeignKey("dbo.TaskEmplyees", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.TaskEmplyees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SprintEmployees", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.SprintEmployees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectEmployees", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectEmployees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DailyReportOfStory", "DailyReportId", "dbo.DailyReports");
            DropForeignKey("dbo.DailyReportOfStory", "StoryId", "dbo.Stories");
            DropIndex("dbo.StoryTaskEmployees", new[] { "StoryTaskId" });
            DropIndex("dbo.StoryTaskEmployees", new[] { "UserId" });
            DropIndex("dbo.DailyReportOfStoryTasks", new[] { "DailyReportId" });
            DropIndex("dbo.DailyReportOfStoryTasks", new[] { "StoryTaskId" });
            DropIndex("dbo.TaskEmplyees", new[] { "StoryId" });
            DropIndex("dbo.TaskEmplyees", new[] { "UserId" });
            DropIndex("dbo.SprintEmployees", new[] { "SprintId" });
            DropIndex("dbo.SprintEmployees", new[] { "UserId" });
            DropIndex("dbo.ProjectEmployees", new[] { "ProjectId" });
            DropIndex("dbo.ProjectEmployees", new[] { "UserId" });
            DropIndex("dbo.CompanyUsers", new[] { "CompanyId" });
            DropIndex("dbo.CompanyUsers", new[] { "UserId" });
            DropIndex("dbo.DailyReportOfStory", new[] { "DailyReportId" });
            DropIndex("dbo.DailyReportOfStory", new[] { "StoryId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.StoryTasks", new[] { "StoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Projects", new[] { "CompanyId" });
            DropIndex("dbo.Sprints", new[] { "ProjectId" });
            DropIndex("dbo.Stories", new[] { "SprintId" });
            DropIndex("dbo.DailyReports", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "DailyReportId" });
            DropIndex("dbo.Comments", new[] { "StoryTaskId" });
            DropIndex("dbo.Comments", new[] { "StoryId" });
            DropIndex("dbo.Comments", new[] { "SprintId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.StoryTaskEmployees");
            DropTable("dbo.DailyReportOfStoryTasks");
            DropTable("dbo.TaskEmplyees");
            DropTable("dbo.SprintEmployees");
            DropTable("dbo.ProjectEmployees");
            DropTable("dbo.CompanyUsers");
            DropTable("dbo.DailyReportOfStory");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.StoryTasks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
            DropTable("dbo.Projects");
            DropTable("dbo.Sprints");
            DropTable("dbo.Stories");
            DropTable("dbo.DailyReports");
            DropTable("dbo.Comments");
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScrumPRO.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public double Statistic { get; set; }
        public int TotalNumberOfTasks { get; set; }
        public int NumberOfTasksDoneCorectly { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Story> Stories { get; set; }
        public ICollection<StoryTask> StoryTasks { get; set; }
        public ICollection<Sprint> Sprints { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryTask> StoryTasks { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /////////
            /////Configuration for ApplicationUser class
            /////////////
            // M:N => ApplicationUser : Company
            modelBuilder.Entity<ApplicationUser>()               
               .HasMany(u => u.Companies)
               .WithMany(c => c.Users)                         
               .Map(m =>
               {
                   m.ToTable("CompanyUsers");
                   m.MapLeftKey("UserId");
                   m.MapRightKey("CompanyId");
               });
             
            // M:N => ApplicationUser : Project
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Projects)
                .WithMany(c => c.Users)
                .Map(m =>
                {
                    m.ToTable("ProjectEmployees");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("ProjectId");
                });

            // M:N => ApplicationUser : Sprint
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Sprints)
                .WithMany(c => c.Users)
                .Map(m =>
                {
                    m.ToTable("SprintEmployees");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("SprintId");
                });

            // M:N => ApplicationUser : Story
            modelBuilder.Entity<ApplicationUser>()
               .HasMany(u => u.Stories)
               .WithMany(c => c.Users)
               .Map(m =>
               {
                   m.ToTable("TaskEmplyees");
                   m.MapLeftKey("UserId");
                   m.MapRightKey("StoryId");
               });

            // M:N => ApplicationUser : StoryTask
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.StoryTasks)
                .WithMany(c => c.Users)
                .Map(m =>
                {
                    m.ToTable("StoryTaskEmployees");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("StoryTaskId");
                });

            /////////////////////////////////////////////////
            /////////
            /////Configuration for Story class
            /////////////
            //M:N => Story : DailyReport
            modelBuilder.Entity<Story>()
                .HasMany(s => s.DailyReports)
                .WithMany(r => r.Stories)
                .Map(m =>
                {
                    m.ToTable("DailyReportOfStory");
                    m.MapLeftKey("StoryId");
                    m.MapRightKey("DailyReportId");
                });

            /////////////////////////////////////////////////
            /////////
            /////Configuration for StoryTask class
            /////////////
            //M:N => StoryTask : DailyReport
            modelBuilder.Entity<StoryTask>()
               .HasMany(s => s.DailyReports)
               .WithMany(r => r.StoryTasks)
               .Map(m =>
               {
                   m.ToTable("DailyReportOfStoryTasks");
                   m.MapLeftKey("StoryTaskId");
                   m.MapRightKey("DailyReportId");
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ScrumPRO.Models;

namespace ScrumPRO.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public double Statistic { get; set; }
        public int TotalNumberOfTasks { get; set; }
        public int NumberOfTasksDoneCorectly { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Story> Stories { get; set; }
        public ICollection<StoryTask> StoryTasks { get; set; }
        public ICollection<Sprint> Sprints { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Company> Companies{ get; set; }
        public DbSet<Project> Project{ get; set; }
        public DbSet<Story> Stories{ get; set; }
        public DbSet<StoryTask> StoryTasks{ get; set; }
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

    }
}
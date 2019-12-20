using AutoMapper;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumPRO.DTO
{
    [Serializable]
    public class DTOAppUser
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }    
        public double Statistic { get; set; }
        public int TotalNumberOfTasks { get; set; }
        public int NumberOfTasksDoneCorectly { get; set; }
        public ICollection<DTOCompany> Companies { get; set; }
        public ICollection<DTOProject> Projects { get; set; }
        public ICollection<DTOStory> Stories { get; set; }
        public ICollection<DTOStoryTask> StoryTasks { get; set; }


        public DTOAppUser GetById(string id)
        {
            var user = db.Users.Find(id);
            return Mapper.Map<DTOAppUser>(user);
        }
    }
}
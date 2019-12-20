using AutoMapper;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumPRO.DTO
{
    [Serializable]
    public class DTODailyReport
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public int Id { get; set; }
        public DateTime DateOfReport { get; set; }
        public String Name { get; set; }
        public ApplicationUser User { get; set; }
        //mora string jer je u klasi ApplicationUser tamo Id tipa string, da bi sam mapirao foreignKey, zato mora
        public string UserId { get; set; }
        public ICollection<Story> Stories { get; set; }
        public ICollection<StoryTask> StoryTasks { get; set; }




        public DTODailyReport GetById(int id)
        {
            var report = db.Stories.Find(id);
            return Mapper.Map<DTODailyReport>(report);
        }
    }
}
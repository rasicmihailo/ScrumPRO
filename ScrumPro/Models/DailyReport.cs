using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScrumPRO.Models
{
    public class DailyReport
    {
        public int Id { get; set; }

        public DateTime DateOfReport { get; set; }
        public String Name { get; set; }
        public ApplicationUser User { get; set; }

        //mora string jer je u klasi ApplicationUser tamo Id tipa string, da bi sam mapirao foreignKey, zato mora
        public string UserId { get; set; }

        public ICollection<Story> Stories { get; set; }
        public ICollection<StoryTask> StoryTasks { get; set; }
    }

}
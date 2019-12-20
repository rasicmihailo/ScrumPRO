using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ScrumPRO.EnumStatus;

namespace ScrumPRO.Models
{
    public class Story
    {
        public byte Id { get; set; }
        
        public String Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public DateTime ExpectedEndDate { get; set; }

        public IssueStatus Status { get; set; }
        public Priorities Priorities { get; set; }
        public SoftwareStatus SoftwareStatus { get; set; }

        public Project Sprint { get; set; }
        
        public byte SprintId { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<DailyReport> DailyReports { get; set; }

    }
}
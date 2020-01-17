using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ScrumPRO.EnumStatus;

namespace ScrumPRO.Models
{
    public class Project
    {
        public byte Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpectedEndDate { get; set; }

        public DateTime EndDate { get; set; }
        public IssueStatus Status { get; set; }
        public Priorities Priorities { get; set; }
        public SoftwareStatus SoftwareStatus { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public Company Company { get; set; }
        public byte CompanyId { get; set; }

    }
}
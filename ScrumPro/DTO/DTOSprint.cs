using AutoMapper;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ScrumPRO.EnumStatus;

namespace ScrumPRO.DTO
{
    [Serializable]
    public class DTOSprint
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public byte Id { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public IssueStatus Status { get; set; }
        public Priorities Priorities { get; set; }
        public SoftwareStatus SoftwareStatus { get; set; }
        public Project Project { get; set; }
        public byte ProjectId { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }


        public DTOSprint GetById(int id)
        {
            var sprint = db.Stories.Find(id);
            return Mapper.Map<DTOSprint>(sprint);
        }
    }
}
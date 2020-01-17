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
    public class DTOProject
    {
        protected ApplicationDbContext db = new ApplicationDbContext();


        public byte Id { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public ICollection<DTOAppUser> Users { get; set; }
        public DTOCompany Company { get; set; }
        public byte CompanyId { get; set; }
        public IssueStatus Status { get; set; }
        public Priorities Priorities { get; set; }
        public SoftwareStatus SoftwareStatus { get; set; }

  
        public DTOProject GetById(int id)
        {
            var project = db.Project.Find(id);
            return Mapper.Map<DTOProject>(project);
        }
    }
}
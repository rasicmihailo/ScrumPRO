using AutoMapper;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumPRO.DTO
{
    [Serializable]
    public class DTOCompany
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public byte Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public ICollection<DTOAppUser> Users { get; set; }


        public DTOCompany GetById(int id)
        {
            var company = db.Companies.SingleOrDefault(c => c.Id == id);
            return Mapper.Map<DTOCompany>(company);
        }

    }
}
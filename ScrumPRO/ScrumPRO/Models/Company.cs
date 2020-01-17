using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumPRO.Models
{
    public class Company
    {
        public byte Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

    }
}
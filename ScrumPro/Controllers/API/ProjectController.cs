using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScrumPRO.DTO;
using AutoMapper;


namespace ScrumPRO.Controllers.API
{
    public class ProjectController : ApiController
    {

        #region ControllerStuff

        public ApplicationDbContext _context { get; set; }

        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion






    }
}

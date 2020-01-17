using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScrumPRO.Models;
using ScrumPRO.DTO;
using AutoMapper;
using System.Data.Entity;

namespace ScrumPRO.Controllers.API
{
    public class CompanyController : ApiController
    {

        #region ControllerStuff

        public ApplicationDbContext _context { get; set; }

        public CompanyController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion


        [HttpGet]
        public IHttpActionResult GetCompany(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
                return BadRequest();

            return Ok(Mapper.Map<Company, DTOCompany>(company));
        }

        [HttpGet]
        public IHttpActionResult GetCompanies()
        {
            var companies = _context.Companies.ToList();

            if (companies.Count == 0 || companies == null)
                return BadRequest();

            return Ok(companies);
        }


        [HttpPost]
        public IHttpActionResult CreateCompany(DTOCompany companyDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Something is wrong with data.");

            var company = Mapper.Map<DTOCompany, Company>(companyDTO);

            _context.Companies.Add(company);        
            _context.SaveChanges();

            companyDTO.Id = company.Id;
            return Created(new Uri(Request.RequestUri + "/" +company.Id), companyDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateCompany(int id, DTOCompany companyDTO)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var company = _context.Companies.SingleOrDefault(c => c.Id == companyDTO.Id);

            if (company == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(companyDTO, company);

            _context.SaveChanges();

            return Ok(company);
        }

    }
}

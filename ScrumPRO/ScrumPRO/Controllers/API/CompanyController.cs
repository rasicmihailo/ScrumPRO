using AutoMapper;
using ScrumPRO.DTO;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        [Route("api/company/{id}")]
        public IHttpActionResult GetCompany(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
                return BadRequest();

            return Ok(Mapper.Map<Company, DTOCompany>(company));
        }

        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult GetCompanies()
        {
            var companies = _context.Companies.ToList();

            if (companies.Count == 0 || companies == null)
                return BadRequest();

            return Ok(companies);
        }


        [HttpPost]
        [Route("api/createcompany")]
        public IHttpActionResult CreateCompany(DTOCompany companyDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Something is wrong with data.");

            var company = Mapper.Map<DTOCompany, Company>(companyDTO);

            _context.Companies.Add(company);
            _context.SaveChanges();

            companyDTO.Id = company.Id;
            return Created(new Uri(Request.RequestUri + "/" + company.Id), companyDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateCompany(int id, DTOCompany companyDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var company = _context.Companies.SingleOrDefault(c => c.Id == companyDTO.Id);

            if (company == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(companyDTO, company);

            _context.SaveChanges();

            return Ok(company);
        }

        [HttpDelete]
        [Route("api/deletecompany/{id}")]
        public IHttpActionResult DeleteCompany(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Companies.Remove(company);

            _context.SaveChanges();

            return Ok(company);
        }

    }
}

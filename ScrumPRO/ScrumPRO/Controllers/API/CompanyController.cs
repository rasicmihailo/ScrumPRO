using AutoMapper;
using ScrumPRO.DTO;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var companies = _context.Companies.Include(c => c.Users).ToList();

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
        [Route("api/company/update")]
        public IHttpActionResult Update([FromBody] DTOCompany companyDTO)
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

        [HttpPost]
        [Route("api/company/add/{id}")]
        public IHttpActionResult Add(/*id==companyId*/ int id, [FromBody] DTOAppUser dtoAppUser)
        {
            //var company = new Company();
            var company = _context.Companies.Include(u => u.Users).SingleOrDefault(c => c.Id == id);

            if (company == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //mora da se ucita iz baze da bi DbContext(tacnije DbTracker) znao da je ucitan u memoriju
            //pa ako se izvrsi neka promena onda ce znati sta da upamti, inace ce praviti gresku!!!
            //zato ne moze ovo => var user = Mapper.Map<DTOAppUser, ApplicationUser>(dtoAppUser); ---- DbTracker ne zna da li se vrse promene!
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(dtoAppUser.Id));

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            company.Users.Add(user);
            user.Companies.Add(company);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("api/company/addusers/{id}")]
        public IHttpActionResult AddUsers(/*id==companyId*/ int id, [FromBody] List<DTOAppUser> dtoAppUsers)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            foreach (var us in dtoAppUsers)
            {
                var user = _context.Users.SingleOrDefault(u => u.Id.Equals(us.Id));

                if (user == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                company.Users.Add(user);
                user.Companies.Add(company);
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}

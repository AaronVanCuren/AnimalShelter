using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AnimalShelter.WebAPI.Controllers
{
    public class CompanyController : ApiController
    {
        private CompanyService CreateCompanyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var companyService = new CompanyService(userId);
            return companyService;
        }

        public IHttpActionResult Get()
        {
            CompanyService companyService = CreateCompanyService();
            var posts = companyService.GetCompanies();
            return Ok(posts);
        }

        public IHttpActionResult Post(CompanyCreate company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyService();

            if (!service.CreateCompany(company))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CompanyService companyService = CreateCompanyService();
            var company = companyService.GetCompanyById(id);
            return Ok(company);
        }

        public IHttpActionResult Put(CompanyRUD company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyService();

            if (!service.UpdateCompany(company))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCompanyService();

            if (!service.DeleteCompany(id))
                return InternalServerError();

            return Ok();
        }
    }
}
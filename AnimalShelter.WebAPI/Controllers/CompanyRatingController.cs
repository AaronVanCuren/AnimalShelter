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
    public class CompanyRatingController : ApiController
    {
        private CompanyRatingService CreateCompanyRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var companyRatingService = new CompanyRatingService(userId);
            return companyRatingService;
        }

        public IHttpActionResult Get()
        {
            CompanyRatingService companyRatingService = CreateCompanyRatingService();
            var ratings = companyRatingService.GetCompanyRatings();
            return Ok(ratings);
        }

        public IHttpActionResult Post(CompanyRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyRatingService();

            if (!service.CreateCompanyRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CompanyRatingService companyRatingService = CreateCompanyRatingService();
            var rating = companyRatingService.GetCompanyRatingByCompanyId(id);
            return Ok(rating);
        }
    }
}
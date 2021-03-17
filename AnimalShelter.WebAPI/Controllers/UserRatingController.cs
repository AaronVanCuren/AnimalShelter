using AnimalShelter.Data;
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
    public class UserRatingController : ApiController
    {
        private UserRatingService CreateUserRatingService()
        {
            var userId = User.Identity.GetUserId();
            ApplicationUserListItem user = new UserService(userId).GetUserByType(UserType.company);
            var userRatingService = new UserRatingService(userId, user.UserType);
            return userRatingService;
        }

        public IHttpActionResult Get()
        {
            UserRatingService userRatingService = CreateUserRatingService();
            var ratings = userRatingService.GetUserRatings();
            return Ok(ratings);
        }

        public IHttpActionResult Post(UserRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserRatingService();

            if (!service.CreateUserRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(string id)
        {
            UserRatingService companyRatingService = CreateUserRatingService();
            var rating = companyRatingService.GetUserRatingById(id);
            return Ok(rating);
        }
    }
}
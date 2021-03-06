using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace AnimalShelter.WebAPI.Controllers
{
    public class UserRatingController : ApiController
    {
        private UserRatingService CreateUserRatingService()
        {
            var userRatingService = new UserRatingService();
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
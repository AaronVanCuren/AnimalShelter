using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace AnimalShelter.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userId = User.Identity.GetUserId();
            var userService = new UserService(userId);
            return userService;
        }

        [HttpGet]
        [Route("api/User/Customers")]
        public IHttpActionResult GetCustomers()
        {
            UserService userService = CreateUserService();
            var user = userService.GetCustomers();
            return Ok(user);
        }

        [HttpGet]
        [Route("api/User/Companies")]
        public IHttpActionResult GetCompanies()
        {
            UserService userService = CreateUserService();
            var user = userService.GetCompanies();
            return Ok(user);
        }

        [HttpGet]
        [Route("api/User/Vets")]
        public IHttpActionResult GetVets()
        {
            UserService userService = CreateUserService();
            var user = userService.GetVets();
            return Ok(user);
        }

        [HttpGet]
        [Route("api/UserByEmail")]
        public IHttpActionResult Get(string email)
        {
            UserService userService = CreateUserService();
            var userEmail = userService.GetUserByEmail(email);
            return Ok(userEmail);
        }

        public IHttpActionResult Put(UserUpdate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(string email)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(email))
                return InternalServerError();

            return Ok();
        }
    }
}
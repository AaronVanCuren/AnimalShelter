using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AnimalShelter.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userId = User.Identity.GetUserId();
            var profileService = new UserService(userId);
            return profileService;
        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            UserService userService = CreateUserService();
            var profiles = userService.GetCustomers();
            return Ok(profiles);
        }

        [HttpGet]
        public IHttpActionResult GetCompanies()
        {
            UserService userService = CreateUserService();
            var profiles = userService.GetCompanies();
            return Ok(profiles);
        }

        [HttpGet]
        public IHttpActionResult GetVets()
        {
            UserService userService = CreateUserService();
            var profiles = userService.GetVets();
            return Ok(profiles);
        }

        public IHttpActionResult Get(string userName)
        {
            UserService profileService = CreateUserService();
            var profile = profileService.GetUserByUserName(userName);
            return Ok(profile);
        }

        public IHttpActionResult Put(RegisterBindingModel user)
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
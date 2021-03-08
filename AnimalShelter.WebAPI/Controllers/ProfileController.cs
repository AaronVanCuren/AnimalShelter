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
    public class ProfileController : ApiController
    {
        private ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var profileService = new ProfileService(userId);
            return profileService;
        }

        public IHttpActionResult Get()
        {
            ProfileService profileService = CreateProfileService();
            var profiles = profileService.GetProfiles();
            return Ok(profiles);
        }

        public IHttpActionResult Post(ProfileCreate profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProfileService();

            if (!service.CreateProfile(profile))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            ProfileService profileService = CreateProfileService();
            var profile = profileService.GetProfileById(id);
            return Ok(profile);
        }

        public IHttpActionResult Put(ProfileRUD profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProfileService();

            if (!service.UpdateProfile(profile))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProfileService();

            if (!service.DeleteProfile(id))
                return InternalServerError();

            return Ok();
        }
    }
}
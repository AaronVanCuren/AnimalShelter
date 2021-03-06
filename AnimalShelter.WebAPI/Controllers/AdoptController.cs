using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace AnimalShelter.WebAPI.Controllers
{
    public class AdoptController : ApiController
    {
        private AdoptService CreateAdoptionServices()
        {
            var userId = (User.Identity.GetUserId());
            var postService = new AdoptService(userId);
            return postService;
        }

        public IHttpActionResult Get()
        {
            AdoptService adoptService = CreateAdoptionServices();
            var adoptions = adoptService.GetAdoptions();
            return Ok(adoptions);
        }

        public IHttpActionResult Post(AdoptCreate adoption)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdoptionServices();

            if (!service.CreateAdoption(adoption))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            AdoptService adoptService = CreateAdoptionServices();
            var adopt = adoptService.GetAdoptionById(id);
            return Ok(adopt);
        }

        public IHttpActionResult Put(AdoptionRUD adoption)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdoptionServices();

            if (!service.UpdateAdoption(adoption))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAdoptionServices();

            if (!service.DeleteAdoption(id))
                return InternalServerError();

            return Ok();
        }
    }
}

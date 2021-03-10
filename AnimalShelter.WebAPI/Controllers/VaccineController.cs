using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnimalShelter.WebAPI.Controllers
{
    public class VaccineController : ApiController
    {
        private VaccineServices CreateVaccineServices()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var vaccineService = new VaccineServices(user);
            return vaccineService;
        }
        public IHttpActionResult Get()
        {
            VaccineServices vaccineServices = CreateVaccineServices();
            var vaccines = vaccineServices.GetVaccines();
            return Ok(vaccines);
        }
        public IHttpActionResult Post(VaccineCreate vaccine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVaccineServices();

            if (!service.CreateVaccine(vaccine))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(VaccineRUD vaccine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVaccineServices();

            if (!service.UpdateVaccine(vaccine))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVaccineServices();

            if (!service.DeleteVaccine(id))
                return InternalServerError();

            return Ok();
        }
    }
}

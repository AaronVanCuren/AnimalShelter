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
    public class AnimalController : ApiController
    {
        private AnimalServices CreateAnimalServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var animalService = new AnimalServices(userId);
            return animalService;
        }
        public IHttpActionResult Get()
        {
            AnimalServices animalServices = CreateAnimalServices();
            var animals = animalServices.GetAnimals();
            return Ok(animals);
        }
    }
}

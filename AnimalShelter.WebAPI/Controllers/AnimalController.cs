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
    public class AnimalController : ApiController
    {
        
        private AnimalServices CreateAnimalServices()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var animalService = new AnimalServices(user);
            return animalService;
        }
        public AnimalController() { }

        public IHttpActionResult Post(AnimalCreate animal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAnimalServices();

            if (!service.CreateAnimal(animal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            AnimalServices animalServices = CreateAnimalServices();
            var animals = animalServices.GetAnimals();
            return Ok(animals);
        }

        public IHttpActionResult GetAnimalId(int id)
        {
            AnimalServices animalService = CreateAnimalServices();
            var animal = animalService.GetAnimalById(id);
            return Ok(animal);
        }

        public IHttpActionResult Put(AnimalRUD animal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAnimalServices();

            if (!service.UpdateAnimal(animal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAnimalServices();

            if (!service.DeleteAnimal(id))
                return InternalServerError();

            return Ok();
        }
    }
}
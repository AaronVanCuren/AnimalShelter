using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AnimalShelter.Testing
{
    [TestClass]
    public class AnimalUnitTest
    {
        public static Guid userId = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

        private AnimalServices _repo = new AnimalServices(userId);

        [TestInitialize]
        public void Seed()
        {
            AnimalCreate animal1 = new AnimalCreate();

            animal1.Name = "Java";
            animal1.Species = SpeciesType.Cat;
            animal1.Breed = "Mainx";
            animal1.Sex = true;
            animal1.Fixed = true;
            animal1.HasShots = true;
            animal1.Age = "6 months";
            animal1.Description = "Happy go lucky Test Cat";
            animal1.AdoptionPrice = 150.00m;
            animal1.IsHouseTrained = false;
            animal1.IsDeclawed = true;
            animal1.IsEdible = false;

            _repo.CreateAnimal(animal1); 
        }

        [TestMethod]
        public void CreateAnimalTest()
        {
            AnimalCreate animal = new AnimalCreate();

            animal.Name = "Java";
            animal.Species = SpeciesType.Cat;
            animal.Breed = "Mainx";
            animal.Sex = true;
            animal.Fixed = true;
            animal.HasShots = true;
            animal.Age = "6 months";
            animal.Description = "Happy go lucky Test Cat";
            animal.AdoptionPrice = 150.00m;
            animal.IsHouseTrained = false;
            animal.IsDeclawed = true;
            animal.IsEdible = false;

            bool wasAdded = _repo.CreateAnimal(animal);

            Assert.IsTrue(wasAdded);
        }
    }
}

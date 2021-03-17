//using AnimalShelter.Data;
//using AnimalShelter.Models;
//using AnimalShelter.Services;
//using AnimalShelter.WebAPI.Controllers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;

//namespace AnimalShelter.Testing
//{
//    [TestClass]
//    public class AnimalUnitTest
//    {
//        public static Guid userId = new Guid("b3dad667-e8f6-4078-8f3f-90168337b01f");
//        private AnimalServices _repo = new AnimalServices(userId);
//        private List<Animal> _animals = new List<Animal>();
//        private ApplicationUser user = new ApplicationUser();
//        [TestInitialize]
//        public void Seed()
//        {

//            List<Vaccine> vaccines = new List<Vaccine>();
//            _animals = new List<Animal>();
//            _repo = new AnimalServices(userId);
//            user = new ApplicationUser();
//            user.ProfileId = 1;
            
            
//            Animal testAnimal = new Animal();
//            testAnimal.AnimalId = 1;
//            testAnimal.AdoptionPrice = 100m;
//            testAnimal.Age = "1 year";
//            testAnimal.Breed = "Golden Retriever";
//            testAnimal.Description = "Is a test";
//            testAnimal.Fixed = true;
//            testAnimal.Vaccines = vaccines;
//            testAnimal.IsDeclawed = true;
//            testAnimal.IsEdible = false;
//            testAnimal.IsHouseTrained = true;
//            testAnimal.Name = "Buddy";
//            testAnimal.Sex = true;
//            testAnimal.Species = SpeciesType.Dog;

//            _animals.Add(testAnimal);


//        }

//        [TestMethod]
//        public void CreateAnimalTest()
//        {
//            List<Vaccine> vaccines = new List<Vaccine>();
//            AnimalCreate animal = new AnimalCreate();

//            animal.Name = "Bob";
//            animal.Species = SpeciesType.Dog;
//            animal.Breed = "Golden";
//            animal.Sex = true;
//            animal.Fixed = true;
//            animal.Vaccines = vaccines;
//            animal.Age = "3 months";
//            animal.Description = "Test doggo.";
//            animal.AdoptionPrice = 150.00m;
//            animal.IsHouseTrained = false;
//            animal.IsDeclawed = true;
//            animal.IsEdible = false;

//            bool wasAdded = _repo.CreateAnimal(animal);

//            Assert.IsTrue(wasAdded);
//        }
//        [TestMethod]
//        public void GetAnimalByIdTest()
//        {
//            AnimalRUD searchResult = _repo.GetAnimalById(1);
//            Assert.AreEqual(searchResult, _repo);

//        }

//        [TestMethod]
//        public void UpdateAnimal()
//        {
//            List<Vaccine> vaccines = new List<Vaccine>();
//            AnimalRUD animal = new AnimalRUD();

//            animal.AnimalId = 1;
//            animal.AdoptionPrice = 200m;
//            animal.Age = "1 year";
//            animal.Breed = "Golden Retriever";
//            animal.Description = "Is a test";
//            animal.Fixed = true;
//            animal.Vaccines = vaccines;
//            animal.IsDeclawed = true;
//            animal.IsEdible = false;
//            animal.IsHouseTrained = true;
//            animal.Name = "Buddy";
//            animal.Sex = true;
//            animal.Species = SpeciesType.Dog;

//            bool wasUpdated = _repo.UpdateAnimal(animal);

//            Assert.IsTrue(wasUpdated);
//        }

//        [TestMethod]
//        public void DeleteAnimalTest()
//        {
//            bool wasRemoved = _repo.DeleteAnimal(1);
//            Assert.IsTrue(wasRemoved);

//        }
//    }

//}

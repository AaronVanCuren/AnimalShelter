using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using AnimalShelter.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AnimalShelter.Testing
{
    public class FakeAnimalService : AnimalServices
    {

        private readonly Guid _userId;

        public AnimalServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAnimal(AnimalCreate animal)
        {
            var entity = new Animal()
            {
                Name = animal.Name,
                Species = animal.Species,
                Breed = animal.Breed,
                Sex = animal.Sex,
                Fixed = animal.Fixed,
                HasShots = animal.HasShots,
                Age = animal.Age,
                Description = animal.Description,
                AdoptionPrice = animal.AdoptionPrice,
                IsHouseTrained = animal.IsHouseTrained,
                IsDeclawed = animal.IsDeclawed,
                IsEdible = animal.IsEdible
            };
            using (var db = new ApplicationDbContext())
            {
                db.Animals.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        public List<AnimalRUD> GetAnimals()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Animals
                        .Select(
                            e => new AnimalRUD
                            {
                                AnimalId = e.AnimalId,
                                Name = e.Name,
                                Species = e.Species,
                                Breed = e.Breed,
                                Sex = e.Sex,
                                Fixed = e.Fixed,
                                HasShots = e.HasShots,
                                Age = e.Age,
                                Description = e.Description,
                                AdoptionPrice = e.AdoptionPrice,
                                IsHouseTrained = e.IsHouseTrained,
                                IsDeclawed = e.IsDeclawed,
                                IsEdible = e.IsEdible
                            });

                return query.ToList();
            }
        }

        public AnimalRUD GetAnimalById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Animals
                        .Single(e => e.AnimalId == id);
                return new AnimalRUD
                {
                    AnimalId = entity.AnimalId,
                    Name = entity.Name,
                    Species = entity.Species,
                    Breed = entity.Breed,
                    Sex = entity.Sex,
                    Fixed = entity.Fixed,
                    HasShots = entity.HasShots,
                    Age = entity.Age,
                    Description = entity.Description,
                    AdoptionPrice = entity.AdoptionPrice,
                    IsHouseTrained = entity.IsHouseTrained,
                    IsDeclawed = entity.IsDeclawed,
                    IsEdible = entity.IsEdible
                };
            }
        }

        public bool UpdateAnimal(AnimalRUD animal)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Animals
                        .Single(e => e.AnimalId == animal.AnimalId);
                entity.Name = animal.Name;
                entity.Species = animal.Species;
                entity.Breed = animal.Breed;
                entity.Sex = animal.Sex;
                entity.Fixed = animal.Fixed;
                entity.HasShots = animal.HasShots;
                entity.Age = animal.Age;
                entity.Description = animal.Description;
                entity.AdoptionPrice = animal.AdoptionPrice;
                entity.IsHouseTrained = animal.IsHouseTrained;
                entity.IsDeclawed = animal.IsDeclawed;
                entity.IsEdible = animal.IsEdible;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteAnimal(int animalId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Animals
                        .Single(e => e.AnimalId == animalId);

                db.Animals.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
    


    










    
       /* public static Guid userId = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

        AnimalController 



        [TestMethod]
        public void CreateAnimalTest()
        {
            
            AnimalCreate animal = new AnimalCreate();
            

            animal.Name = "Bob";
            animal.Species = SpeciesType.Dog;
            animal.Breed = "Golden";
            animal.Sex = true;
            animal.Fixed = true;
            animal.HasShots = true;
            animal.Age = "3 months";
            animal.Description = "Test doggo.";
            animal.AdoptionPrice = 150.00m;
            animal.IsHouseTrained = false;
            animal.IsDeclawed = true;
            animal.IsEdible = false;

            bool wasAdded = _repo.CreateAnimal(animal);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetAnimalByIdTest()
        {
            AnimalRUD searchResult = _repo.GetAnimalById(1);
            Assert.AreEqual(searchResult, _repo);

        }

        [TestMethod]
        public void DeleteAnimalTest()
        {
            bool wasRemoved = _repo.DeleteAnimal(1);
            Assert.IsTrue(wasRemoved);

        }


        Animal GetAnimal()
        {
            return new Animal() { AnimalId = 1, Name = "Test Name", Species = 0 };
        }

        [TestMethod]
        public void GetAnimalTest()
        {
            var testAnimal = GetAnimal();
            var controller = new AnimalController(testAnimal);
        }*/
    }
}

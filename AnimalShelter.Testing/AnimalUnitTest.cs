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
        
        private Guid _userId;
        
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
            animal1.IsDeclawed = true;

            AnimalCreate animal2 = new AnimalCreate();
            
            animal2.Name = "Script";
            animal2.Species = SpeciesType.Bunny;
            animal2.Breed = "Hare";
            animal2.Sex = false;
            animal2.Fixed = false;
            animal2.HasShots = false;
            animal2.Age = "2 months";
            animal2.Description = "Happy go lucky Test Bunny";
            animal2.AdoptionPrice = 30.00m;
            animal2.IsEdible = true;

            AnimalCreate animal3 = new AnimalCreate();
            
            animal3.Name = "JSON";
            animal3.Species = SpeciesType.Dog;
            animal3.Breed = "Terrier";
            animal3.Sex = true;
            animal3.Fixed = true;
            animal3.HasShots = true;
            animal3.Age = "1 year";
            animal3.Description = "Happy go lucky Test Dog";
            animal3.AdoptionPrice = 125.00m;
            animal3.IsHouseTrained = true;

            AnimalServices animalServices = new AnimalServices(_userId);
            animalServices.CreateAnimal(animal1);
            animalServices.CreateAnimal(animal2);
            animalServices.CreateAnimal(animal3);

        }
        [TestMethod]
        public void CreateAnimal()
        {
            AnimalCreate animal4 = new AnimalCreate();
            
            animal4.Name = "Sharp"; 
            animal4.Species = SpeciesType.Bunny; 
            animal4.Breed = "Cotton tail"; 
            animal4.Sex = false; 
            animal4.Fixed = false; 
            animal4.HasShots = true;  
            animal4.Age = "2 weeks"; 
            animal4.Description = "Happy bunny"; 
            animal4.AdoptionPrice = 45.00m; 
            animal4.IsEdible = false;

            AnimalServices createAnimal = new AnimalServices(_userId);
            bool wasAdded = createAnimal.CreateAnimal(animal4);

            Assert.IsTrue(wasAdded);
        }
    }
}

/*using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AnimalShelter.Testing
{
    [TestClass]
    public class PostUnitTest
    {

        private static Guid _userId = new Guid("b3dad667-e8f6-4078-8f3f-90168337b01f");
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private RegisterBindingModel _customer;
        private RegisterBindingModel _company;
        private RegisterBindingModel _vet;
        private ApplicationUser customer;
        private ApplicationUser company;
        private ApplicationUser vet;

        [TestInitialize]
        public void Seed()
        {
            _customer = new RegisterBindingModel()
            {
                UserType = UserType.customer,
                FullName = "John Smith",
                UserName = "jSmith",
                Email = "johnsmith@gmail.com",
                PhoneNumber = "260-123-4567",
                Address = "123 Main St",
                Password = "Test1!",
                ConfirmPassword = "Test1!"
            };

            customer = new ApplicationUser()
            {
                UserId = _userId,
                ProfileId = 1,
                UserType = _customer.UserType,
                FullName = _customer.FullName,
                UserName = _customer.UserName,
                Email = _customer.Email,
                PhoneNumber = _customer.PhoneNumber,
                Address = _customer.Address,
                PasswordHash = _customer.Password
            };

            _company = new RegisterBindingModel()
            {
                UserType = UserType.company,
                CompanyName = "ABC Company",
                UserName = "ABCcompany",
                Email = "abc_company@gmail.com",
                PhoneNumber = "800-123-4567",
                Address = "456 Main St",
                Password = "Test1!",
                ConfirmPassword = "Test1!"
            };

            company = new ApplicationUser()
            {
                UserId = _userId,
                ProfileId = 2,
                UserType = _company.UserType,
                CompanyName = _company.CompanyName,
                UserName = _company.UserName,
                Email = _company.Email,
                PhoneNumber = _company.PhoneNumber,
                Address = _company.Address,
                PasswordHash = _company.Password
            };

            _vet = new RegisterBindingModel()
            {
                UserType = UserType.vet,
                FullName = "Dr. Jane",
                UserName = "VetJane",
                Email = "jane@gmail.com",
                PhoneNumber = "800-987-6543",
                Address = "789 Main St",
                Password = "Test1!",
                ConfirmPassword = "Test1!"
            };

            vet = new ApplicationUser()
            {
                UserId = _userId,
                ProfileId = 3,
                UserType = _vet.UserType,
                FullName = _vet.FullName,
                UserName = _vet.UserName,
                Email = _vet.Email,
                PhoneNumber = _vet.PhoneNumber,
                Address = _vet.Address,
                PasswordHash = _vet.Password
            };

            _db.Users.Add(customer);
            _db.Users.Add(company);
            _db.Users.Add(vet);

            AnimalServices animalServices = new AnimalServices(_userId);

            List<Vaccine> vaccines = new List<Vaccine>();
            AnimalCreate animal1 = new AnimalCreate();
            {
                animal1.AdoptionPrice = 100m;
                animal1.Age = "1 year";
                animal1.Breed = "Golden Retriever";
                animal1.Description = "Is a test";
                animal1.Fixed = true;
                animal1.Vaccines = vaccines;
                animal1.IsDeclawed = true;
                animal1.IsEdible = false;
                animal1.IsHouseTrained = true;
                animal1.Name = "Buddy";
                animal1.Sex = true;
                animal1.Species = SpeciesType.Dog;
            }
            
            animalServices.CreateAnimal(animal1);
        }

        [TestMethod]
        public void CreateUpdateDeletePost()
        {
            PostServices postServices = new PostServices(_userId, UserType.company);

            PostCreate post = new PostCreate();
            post.AnimalId = 1;

            bool wasAdded = postServices.CreatePost(post);

            Assert.IsTrue(wasAdded);

        }
        [TestMethod]
        public void DeletePost()
        {
            PostServices postServices = new PostServices(_userId, UserType.company);

            bool wasDeleted = postServices.DeletePost(8);

            Assert.IsTrue(wasDeleted);
        }
        

    }
}
*/
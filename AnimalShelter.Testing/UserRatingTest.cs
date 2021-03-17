/*using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnimalShelter.Testing
{
    [TestClass]
    public class UserRatingTest
    {
        public static Guid userId = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

        private UserRatingService _repo = new UserRatingService(userId, UserType.customer);
        //private ApplicationDbContext _db = new ApplicationDbContext();

        [TestInitialize]
        public void Seed()
        {
            UserRatingCreate ratingTest = new UserRatingCreate();
            ratingTest.ProfileId = 1;
            ratingTest.AdoptingProcessScore = 5;
            ratingTest.FriendlinessScore = 4;

            //_repo.CreateUserRating(ratingTest);
        }

        [TestMethod]
        public void AddRatingTest()
        {
            UserRatingCreate ratingTest = new UserRatingCreate();
            ratingTest.ProfileId = 1;
            ratingTest.AdoptingProcessScore = 5.0;
            ratingTest.FriendlinessScore = 4.0;

            bool wasAdded = _repo.CreateUserRating(ratingTest);

            Assert.IsTrue(wasAdded);
        }
    }
}
*/
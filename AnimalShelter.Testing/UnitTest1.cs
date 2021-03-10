using AnimalShelter.Data;
using AnimalShelter.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnimalShelter.Testing
{
    [TestClass]
    public class AdoptControllerTest
    {
        /*private AdoptController _field;
        private Adoption adoption;

        [TestInitialize]
        public void Seed()
        {
            _field = new AdoptController();
            adoption = new Adoption();
            
            
            
            Adoption testAdoption = new EmployeeBadge();
            testBadge.DoorAccess = new List<string>();

            testBadge.BadgeID = 1;
            testBadge.DoorAccess.Add("A1");
            _repo.AddBadgeToDictionary(testBadge);*/


        [TestMethod]
        public void TestMethod1()
        {
            // Set up Prerequisites   
            var controller = new AdoptController();
            // Act on Test  
            var response = controller.Get(1);
            var contentResult = response asOkNegotiatedContentResult<Department>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.DepartmentId);
        }
    }
}

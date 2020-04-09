using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsContent_Tests
{
    [TestClass]
    public class ClaimsRepoTests
    {
        [TestMethod]
        public void AddClaimToDirectory_Test()
        {
            ClaimsContent firstClaim = new ClaimsContent();
            ClaimsRepo repo = new ClaimsRepo();

            bool addClaim = repo.AddClaimToDirectory(firstClaim);

            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetDirectory_Test()
        {
            ClaimsContent testClaim = new ClaimsContent();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToDirectory(testClaim);

            Queue<ClaimsContent> testQueue = repo.GetClaims();
            bool directoryHasClaim = testQueue.Contains(testClaim);

            Assert.IsTrue(directoryHasClaim);
        }

        private ClaimsContent _claims;
        private ClaimsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claims = new ClaimsContent(5, TypeOfClaim.Car, "Accident on 69", 555.55m, 
                new DateTime(2019, 12, 25), new DateTime(2019, 12, 30), true);
            _repo.AddClaimToDirectory(_claims);
        }

        [TestMethod]
        public void GetByClaimId_Test()
        {
            ClaimsContent idSearch = _repo.GetClaimById(5);
            Assert.AreEqual(_claims, idSearch);
        }

        [TestMethod]
        public void UpdateClaim_Test()
        {
            ClaimsContent newClaim = new ClaimsContent(5, TypeOfClaim.Car, "Accident on 69", 555.55m,
                new DateTime(2019, 12, 25), new DateTime(2019, 12, 30), true);
            bool updateClaim = _repo.UpdateExistingClaim(5, newClaim);
            Assert.IsTrue(updateClaim);
        }
    }
}

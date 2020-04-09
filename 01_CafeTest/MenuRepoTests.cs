using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeTests
{
    [TestClass]
    public class MenuRepoTests
    {
        [TestMethod]
        public void AddToMenuListing_Test()
        {
            //Arrange//
            MenuContent firstItem = new MenuContent();
            MenuRepo repo = new MenuRepo();

            //Act//
            bool addResult = repo.AddItemToListing(firstItem);

            //Assert//
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenuListing_Test()
        {
            //Arrange//
            MenuContent testItem = new MenuContent();
            MenuRepo repo = new MenuRepo();
            repo.AddItemToListing(testItem);

            //Act//
            List<MenuContent> testListing = repo.GetMenuContentListing();
            bool listingHasItem = testListing.Contains(testItem);

            //Assert//
            Assert.IsTrue(listingHasItem);
        }

        private MenuContent _content;
        private MenuRepo _repo;

     
        [TestInitialize]
        public void AddMenuItem_Test()
        {
            _repo = new MenuRepo();
            _content = new MenuContent(55, "Chaplin's Spaghetti", "Classic spaghetti and meatballs enough for two.", "Tomato, beef, wheat.", 12.99m);
            _repo.AddItemToListing(_content);
        }

        [TestMethod]
        public void GetByMealNumber_Test()
        {
            MenuContent result = _repo.OrderByNumber(55);
            Assert.AreEqual(_content, result);
        }

        /*[TestMethod]
        public void RemoveMenuItem_Test()
        {
            MenuContent noLongerServing = _repo.GetMenuContentListing("055");

            bool removeItem = _repo.DeleteItemFromListing(noLongerServing);
            Assert.IsTrue(removeItem);
        }*/
    }
}

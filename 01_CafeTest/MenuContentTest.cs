using System;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class MenuContentTest
    {
        [TestMethod]
        public void SetName_ShouldBeCorrect()
        {
            MenuContent item = new MenuContent();
            item.MealName = "Royale w/ Cheese";
            string expected = "Royale w/ Cheese";
            string actual = item.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}

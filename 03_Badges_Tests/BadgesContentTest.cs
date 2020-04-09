using System;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgesTests
{
    [TestClass]
    public class BadgesContentTest
    {
        [TestMethod]
        public void SetId_Test()
        {
            BadgesContent badge = new BadgesContent();
            badge.BadgeId = 55555;
            int expected = 55555;
            int actual = badge.BadgeId;

            Assert.AreEqual(expected, actual);
        }
    }
}

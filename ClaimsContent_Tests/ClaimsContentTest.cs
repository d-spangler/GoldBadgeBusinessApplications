using System;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTests
{
    [TestClass]
    public class ClaimsContentTest
    {
        [TestMethod]
        public void SetId_ShouldSetCorrectInt()
        {
            ClaimsContent id = new ClaimsContent();
            id.ClaimId = 1;
            int expected = 1;
            int actual = id.ClaimId;

            Assert.AreEqual(expected, actual);
        }
    }
}

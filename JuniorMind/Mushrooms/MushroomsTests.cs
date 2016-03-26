using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mushrooms
{
    [TestClass]
    public class MushroomsTests
    {
        [TestMethod]
        public void numberOfRedMushrooms()
        {
            int nrRedMushrooms = (int)CalculateNumberOfRedMushrooms(6, 2);
            Assert.AreEqual(4, nrRedMushrooms);
        }

        [TestMethod]
        public void numberOfRedMushroomsForOddTotalNumber()
        {
            int nrRedMushrooms = (int)CalculateNumberOfRedMushrooms(7, 2.5);
            Assert.AreEqual(5, nrRedMushrooms);
        }

        
        double CalculateNumberOfRedMushrooms(int totalNumberOfMushrooms, double multiplier)
        {
            return multiplier * totalNumberOfMushrooms / (multiplier + 1);
        }
    }
}

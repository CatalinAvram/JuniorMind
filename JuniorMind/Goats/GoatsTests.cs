using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*În X zile Y capre mănâncă Z kg fân. Câte kg de fân mănâncă Q capre în W zile?*/
namespace Goats
{
    [TestClass]
    public class GoatsTests
    {
        [TestMethod]
        public void NumberOfKilograms()
        {
            int totalKilograms = FindNumberOfKilograms(5, 4);
            Assert.AreEqual(20, totalKilograms);
        }
        int FindNumberOfKilograms(int numberOfGoats, int numberOfDays)
        {
            return numberOfGoats * numberOfDays;
        }
    }
}

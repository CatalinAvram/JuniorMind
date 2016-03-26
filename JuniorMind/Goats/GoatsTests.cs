using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goats
{
    [TestClass]
    public class GoatsTests
    {
        [TestMethod]
        public void NumberOfKilogramsForSecondFlock()
        {
            decimal secondFlockKilograms = FindNumberOfKilograms(3, 6, 9, 2, 4);
            Assert.AreEqual(4, secondFlockKilograms);
        }
        decimal FindNumberOfKilograms(int firstFlockNumberOfDays, int firstFlockNumberOfGoats, int firstFlockEatenKilograms, int secondFlockNumberOfDays, int secondFlockNumberOfGoats)
        {
            decimal kilogramsPerGoat = firstFlockEatenKilograms / firstFlockNumberOfGoats;
            decimal kilogramsPerGoatPerDay = kilogramsPerGoat / firstFlockNumberOfDays;
            decimal secondFlockEatenKilograms = kilogramsPerGoatPerDay * secondFlockNumberOfDays * secondFlockNumberOfGoats;
            return secondFlockEatenKilograms;
        }
    }
}

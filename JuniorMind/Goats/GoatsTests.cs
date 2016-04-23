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
            decimal secondFlockKilograms = FindNumberOfKilograms(1, 1, 3, 2, 1);
            Assert.AreEqual(6, secondFlockKilograms);
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

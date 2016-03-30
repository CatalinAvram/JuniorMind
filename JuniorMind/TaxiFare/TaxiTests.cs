using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*O firmă de taxi taxează în funcție de numărul de kilometri, în plus are tarife diferențiate pentru zi și pentru noapte.
Pe timp de zi (între 8:00 și ora 21:00) tarifele sunt:
    1-20km - 5 lei / km
    21-60km - 4 lei / km dar se taxează dus și întors
    peste 60km - 3 lei / km se taxează dus și întors
Pe timp de noapte (între ora 21:00 și 8:00) tarifele sunt:
    1-20km - 7 lei / km
    21-60km - 5 lei / km dar se taxează dus și întors
    peste 60km - 4 lei / km se taxează dus și întors
Dacă ști ce distanță trebuie parcursă și ora din zi, calculează tariful.*/

namespace TaxiFare
{
    [TestClass]
    public class TaxiTests
    {
        [TestMethod]
        public void SmallDistanceDuringDay()
        {
            Assert.AreEqual(25, CalculateTaxiFare(5, 13));
        }

        [TestMethod]
        public void MediumDistanceDuringDay()
        {
            Assert.AreEqual(240, CalculateTaxiFare(30, 16));
        }

        [TestMethod]
        public void HighDistanceDuringDay()
        {
            Assert.AreEqual(420, CalculateTaxiFare(70, 19));
        }

        [TestMethod]
        public void SmallDistanceDuringNight()
        {
            Assert.AreEqual(70, CalculateTaxiFare(10, 3));
        }
        [TestMethod]
        public void MediumDistanceDuringNight()
        {
            Assert.AreEqual(300, CalculateTaxiFare(30, 5));
        }

        [TestMethod]
        public void HighDistanceDuringNight()
        {
            Assert.AreEqual(560, CalculateTaxiFare(70, 6));
        }

        decimal CalculateTaxiFare(int distance, int clockTime)
        {
            int[] dayTimePrices = { 5, 4, 3 };
            int[] nightTimePrices = { 7, 5, 4 };

            if (distance >= 1 && distance <= 20 && dayTime(clockTime))
                return distance * dayTimePrices[0];
            if (distance >= 21 && distance <= 60 && dayTime(clockTime))
                return 2 * distance * dayTimePrices[1];
            if (distance > 60 && clockTime >= 8 && dayTime(clockTime))
                return 2 * distance * dayTimePrices[2];

            if (distance >= 1 && distance <= 20 && !dayTime(clockTime))
                return distance * nightTimePrices[0];
            if (distance >= 21 && distance <= 60 && !dayTime(clockTime))
                return 2 * distance * nightTimePrices[1];
            if (distance > 60 && !dayTime(clockTime))
                return 2 * distance * nightTimePrices[2];
            return 0;
        }

        bool dayTime(int clockTime)
        {
            if (clockTime >= 8 && clockTime <= 21)
                return true;
            return false;
        }
    }
}

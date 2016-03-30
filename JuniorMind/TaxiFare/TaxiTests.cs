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
        decimal CalculateTaxiFare(int distance, int clockTime)
        {
            if (distance >= 1 && distance <= 20 && clockTime >= 8 && clockTime <= 21)
                return distance * 5;
            if (distance >= 21 && distance <= 60 && clockTime >= 8 && clockTime <= 21)
                return 2 * distance * 4;
            if (distance > 60 && clockTime >= 8 && clockTime <= 21)
                return 2 * distance * 3;

            if (distance >= 1 && distance <= 20 && clockTime < 8 || clockTime > 21)
                return distance * 7;
            if (distance >= 21 && distance <= 60 && clockTime < 8|| clockTime > 21)
                return 2 * distance * 5;
            if (distance > 60 && clockTime < 8 || clockTime > 21)
                return 2 * distance * 4;

            return 0;

        }
    }
}

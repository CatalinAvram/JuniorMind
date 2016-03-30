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
            decimal[] dayTimePrices = { 5, 4, 3 };
            decimal[] nightTimePrices = { 7, 5, 4 };

            decimal[] shortDistances = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            decimal[] mediumDistances = { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                                          41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };

            decimal[] prices = DayTime(clockTime) ? dayTimePrices : nightTimePrices;

            if (IsInArray(distance, shortDistances))
                return distance * prices[0];
            if (IsInArray(distance, mediumDistances))
                return 2 * distance * prices[1];
            return 2 * distance * prices[2];
        }

        bool DayTime(int clockTime)
        {
            if (clockTime >= 8 && clockTime <= 21)
                return true;
            return false;
        }

        bool IsInArray(int elementToBeChecked, decimal[] arrayToBeSearchedIn)
        {
            bool answer = false;
            for (int i = 0; i < arrayToBeSearchedIn.Length; i++)
                if (elementToBeChecked == arrayToBeSearchedIn[i])
                {
                    answer = true;
                    break;
                }
            return answer;                       
        }
    }
}

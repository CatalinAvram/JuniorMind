using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Doi prieteni au cumpărat un pepene de X kg, și doresc să îl împartă.
Singura lor dorință e ca fiecare să primească un număr par de kg din pepene.
E ok și dacă nu primesc aceeași cantitate.
Scrie un program care răspunde cu DA dacă pepenele poate fi împărțit cum își doresc cei doi prieteni, 
și cu NU în caz contrar.*/

namespace Watermelon
{
    [TestClass]
    public class WatermelonTests
    {
        [TestMethod]
        public void SplittedWatermelonYes()
        {
            String answer = checkIfCanBeSplittedInEvenParts(4);
            Assert.AreEqual("DA", answer);
        }
        [TestMethod]
        public void SplittedWatermelonNo()
        {
            String asnwer = checkIfCanBeSplittedInEvenParts(5);
            Assert.AreEqual("NU", asnwer);
        }
        [TestMethod]
        public void WatermelonWithWeightTwo() 
        {
            String asnwer = checkIfCanBeSplittedInEvenParts(2);
            Assert.AreEqual("NU", asnwer);
        }
        string checkIfCanBeSplittedInEvenParts(int watermelonWeight)
        {
            if (watermelonWeight == 2)
                return ("NU"); 
            return (watermelonWeight % 2 == 0 ? "DA" : "NU");
        }
    }
}

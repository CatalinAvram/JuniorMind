using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Primăria a decis să paveze piața mare din centru orașului cu piatră cubică. Piața e un dreptunghi de m x n, 
iar piatra cubică are dimensiunea de a x a.
De câte bucăți de piatră e nevoie pentru a acoperi piața?
Piatra cubică se vinde la bucată, deci nu pot fi cumpărate jumătăți

Exemplu: dacă piața e de 6x6 și piatra cubică e de 4x4, rezultatul trebuie să fie 4*/

namespace SquarePavement
{
    [TestClass]
    public class PavementTests
    {
        [TestMethod]
        public void NumberOfStones()
        {
            Assert.AreEqual(4, CalculateNumberOfStones(6, 6, 4));
        }
        decimal CalculateNumberOfStones(decimal lengthOfSquare, decimal widthOfSquare, decimal stoneDimension)
        {
            return Math.Ceiling(lengthOfSquare / stoneDimension) + Math.Ceiling(widthOfSquare / stoneDimension);
        }
    }
}

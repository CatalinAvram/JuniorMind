using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Un om de știință vrea să știe toate numerele al căror cub se termină cu 888.
Ajută-l prin a-i face un program care pentru numărul k, întoarce al k-lea număr al cărui cub e 888.

Exemplu: dacă k e 1, rezultatul e 192*/
namespace Cube
{
    [TestClass]
    public class CubeTests
    {
        [TestMethod]
        public void FirstNumber()
        {
            Assert.AreEqual(192, GiveKthNumberWithRequestedCubeEndingDigits(1));
        }

        [TestMethod]
        public void SecondNumber()
        {
            Assert.AreEqual(442, GiveKthNumberWithRequestedCubeEndingDigits(2));
        }

        private int GiveKthNumberWithRequestedCubeEndingDigits(int k)
        {
            
            int counter = 0;
            int number = 191;
           
            while(counter < k)
            {
                number++;
                if (HasDesiredEnding(ComputeCube(number), 888))
                    counter++;
            }
            return number;
        }

        private static int ComputeCube(int number)
        {
            return (int)Math.Pow(number, 3);
        }

        private static bool HasDesiredEnding(int number, int desiredEnding)
        {
            return number % 1000 == desiredEnding;
        }
    }
}

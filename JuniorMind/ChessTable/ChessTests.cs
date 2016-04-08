using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//Calculează câte pătrate se pot forma pe o tablă de șah de dimensiunea de 8 x 8.

namespace ChessTable
{
    [TestClass]
    public class ChessTests
    {
        [TestMethod]
        public void FourSquares()
        {
            Assert.AreEqual(4, ComputeNumberOfSquares(2, 2));
        }

        [TestMethod]
        public void ThreeMultipliedByThreeTable()
        {
            Assert.AreEqual(13, ComputeNumberOfSquares(3,3));
        }

        private int ComputeNumberOfSquares(int length, int width)
        {
            int numberOfSquares = 1;
            while(length > 1)
            {
                numberOfSquares += length * width;
                length--;
                width--;
            }

            return numberOfSquares - 1;
        }
    }
}

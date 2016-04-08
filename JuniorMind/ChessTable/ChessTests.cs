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
            Assert.AreEqual(13, ComputeNumberOfSquares(3, 3));
        }

        [TestMethod]
        public void FourMultipliedByFourTable()
        {
            Assert.AreEqual(29, ComputeNumberOfSquares(4, 4));
        }

        [TestMethod]
        public void EightMultipliedByEightTable()
        {
            Assert.AreEqual(203, ComputeNumberOfSquares(8, 8));
        }
        private int ComputeNumberOfSquares(int length, int width)
        {
            int numberOfSquares = 0;
            while(length > 1)
            {
                numberOfSquares += length * width;
                length--;
                width--;
            }

            return numberOfSquares;
        }
    }
}

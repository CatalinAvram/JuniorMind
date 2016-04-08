using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        private int ComputeNumberOfSquares(int length, int width)
        {
            return length * width;
        }
    }
}

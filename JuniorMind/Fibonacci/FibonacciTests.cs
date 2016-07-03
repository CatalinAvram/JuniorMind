using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Calculează recursiv al k-lea număr din șirul Fibonacci. 
Șirul Fibonacii este o serie de numere: 0, 1, 1, 2, 3, 5, 8, 13, 21, ...*/

namespace Fibonacci
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void FirstElement()
        {
            Assert.AreEqual(0, GiveFibonacciElement(0));
        }

        [TestMethod]
        public void ThirdElement()
        {
            Assert.AreEqual(1, GiveFibonacciElement(2));
        }

        [TestMethod]
        public void FifthElement()
        {
            Assert.AreEqual(5, GiveFibonacciElement(5));
        }

        int GiveFibonacciElement(int k)
        {
            int previous = 0;
            return GiveFibonacciElement(k, ref previous);
        }

        int GiveFibonacciElement(int k, ref int previous)
        {
            if (k < 2)
                return k;
            int beforePrevious = 0;
            previous = GiveFibonacciElement(k - 1, ref beforePrevious);
            return previous + beforePrevious;
        }
    }
}

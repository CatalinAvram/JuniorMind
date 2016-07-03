using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Calculează recursiv al k-lea număr din șirul Fibonacci. 
Șirul Fibonacii este o serie de numere: 0, 1, 1, 2, 3, 5, 8, 13, 21, ...*/

namespace Fibonacci
{
    [TestClass]
    public class UnitTest1
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

        int GiveFibonacciElement(int k)
        {
            if (k < 2)
                return k;
            return GiveFibonacciElement(k - 1) + GiveFibonacciElement(k - 2);
        }
    }
}

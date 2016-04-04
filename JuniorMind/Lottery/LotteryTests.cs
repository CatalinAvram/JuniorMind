using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Vrei să participi la jocul de noroc 6 din 49 cu o singură variantă (simplă).

Calculează ce șanse ai să câștigi la categoria I (6 numere)?

Calculează ce șanse ai să câștigi la categoria II (5 numere)?

Calculează ce șanse ai să câștigi la categoria III (4 numere)?

Calculează și ce șanse ai la categoria I la 5 din 40?*/

namespace Lottery
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void SixCorrectNumbers()
        {
            Assert.AreEqual(1 / 13983816, WinningProbability(6, 49));
        }

        [TestMethod]
        public void Factorial()
        {
            Assert.AreEqual(120, ComputeFactorialNumber(5));
        }

        [TestMethod]
        public void Combinations()
        {
            Assert.AreEqual(35, ComputeNumberOfCombinations(7, 3));
        }

        decimal WinningProbability(int correctNeededNumbers, int totalNumbers)
        {
            return 1;
        }

        int ComputeFactorialNumber(int number)
        {
            if (number == 0)
                return 1;

            int factorial = 1;
            for (int i = 2; i <= number; i++)
                factorial *= i;
            return factorial;
        }

        int ComputeNumberOfCombinations(int numberOfElements, int numberOfTakes)
        {
            int factorialNumberOfElements = ComputeFactorialNumber(numberOfElements);
            int factorialNumberOfTakes = ComputeFactorialNumber(numberOfTakes);
            return factorialNumberOfElements / (ComputeFactorialNumber(numberOfElements - numberOfTakes) * factorialNumberOfTakes);
        }
    }
}
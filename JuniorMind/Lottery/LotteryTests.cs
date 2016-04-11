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
            Assert.AreEqual((double)1 / 13983816, WinningProbability(6, 6, 49));
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

        [TestMethod]
        public void SecondCategory()
        {
            Assert.AreEqual(0.0000184, WinningProbability(6, 5, 49), 0.000001);
        }

        [TestMethod]
        public void ThirdCategory()
        {
            Assert.AreEqual(0.000969, WinningProbability(6, 4, 49), 0.000001);
        }

        [TestMethod]
        public void FiveOutOfForty()
        {
            Assert.AreEqual((double)1 / 658008, WinningProbability(5, 5, 40), 0.000001);
        }

        double WinningProbability(int correctNeededNumbers, int guessedNumbers, int totalNumbers)
        {
            return ComputeNumberOfCombinations(correctNeededNumbers, guessedNumbers) * ComputeNumberOfCombinations((totalNumbers - correctNeededNumbers), (correctNeededNumbers - guessedNumbers)) / ComputeNumberOfCombinations(totalNumbers, correctNeededNumbers); 
        }

        double ComputeFactorialNumber(int number)
        {
            if (number == 0)
                return 1;

            double factorial = 1;
            for (int i = 2; i <= number; i++)
                factorial *= i;
            return factorial;
        }

        double ComputeNumberOfCombinations(int numberOfElements, int numberOfTakes)
        {
            double factorialNumberOfElements = ComputeFactorialNumber(numberOfElements);
            double factorialNumberOfTakes = ComputeFactorialNumber(numberOfTakes);

            return factorialNumberOfElements / (ComputeFactorialNumber(numberOfElements - numberOfTakes) * factorialNumberOfTakes);
        }
    }
}
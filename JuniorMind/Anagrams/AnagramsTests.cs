using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Pentru un cuvânt dat calculează numărul de anagramări posibile.Nu trebuie ca cuvintele rezultate să existe în dicționar.
Anagramările nu trebuie să se repete și nu trebuie generate anagramările, doar să se calculeze numărul lor.*/
namespace Anagrams
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void TestForTwoLetters()
        {
            Assert.AreEqual(2, ComputeNumberOfAnagrams("ab"));
        }

        int ComputeNumberOfAnagrams(string word)
        {
            return ComputeFactorial(word.Length);
        }

        private static int ComputeFactorial(int number)
        {
            int factorial = 1;
            for (int i = 2; i <= number; i++)
                factorial *= i;
            return factorial;
        }
    }
}

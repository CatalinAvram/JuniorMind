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

        [TestMethod]
        public void ThreeDistinctLetters()
        {
            Assert.AreEqual(6, ComputeNumberOfAnagrams("abc"));
        }

        [TestMethod]
        public void TwoIdenticalLetters()
        {
            Assert.AreEqual(1, ComputeNumberOfAnagrams("aa"));
        }

        [TestMethod]
        public void MoreRepeatingLetters()
        {
            Assert.AreEqual(6, ComputeNumberOfAnagrams("aabb"));
        }

        int ComputeNumberOfAnagrams(string word)
        {
            int productOfRepetitions = 1;
            for (int c = 'a'; c < 'z'; c++)
                productOfRepetitions *= ComputeFactorial(GetNumberOfRepetions(c, word));
            return ComputeFactorial(word.Length) / productOfRepetitions;
        }

        private int GetNumberOfRepetions(int charToCheck, string word)
        {
            int repetitionsNumber = 0;
            for (int i = 0; i < word.Length; i++)
                if (charToCheck == word[i])
                    repetitionsNumber++;
            return repetitionsNumber;

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

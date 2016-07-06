using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Inversează un string folosind recursivitatea*/

namespace ReversedString
{
    [TestClass]
    public class ReversedTests
    {
        [TestMethod]
        public void OneLetter()
        {
            Assert.AreEqual("a", Reverse("a"));
        }

        [TestMethod]
        public void ShortString()
        {
            Assert.AreEqual("ea", Reverse("ae"));
        }

        [TestMethod]
        public void LongString()
        {
            Assert.AreEqual("fedcba", Reverse("abcdef"));
        }       

        string Reverse(string toBeReversed)
        {
            if (toBeReversed.Length <= 1)
                return toBeReversed;
            char ch = toBeReversed[0];
            return Reverse(toBeReversed.Substring(1, toBeReversed.Length - 1)) + ch;
        }
    }
}

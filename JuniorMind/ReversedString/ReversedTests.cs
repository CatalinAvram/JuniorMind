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
            Assert.AreEqual("a", ReverseString("a"));
        }

        [TestMethod]
        public void ShortString()
        {
            Assert.AreEqual("ea", ReverseString("ae"));
        }
        string ReverseString(string toBeReversed)
        {
            if (toBeReversed.Length <= 1)
                return toBeReversed;
            return ReverseString(toBeReversed[toBeReversed.Length - 1].ToString()) + ReverseString(toBeReversed[toBeReversed.Length - 2].ToString());                   
        }
    }
}

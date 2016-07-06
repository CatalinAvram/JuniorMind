using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Înlocuiește un caracter dintr-un string cu un alt string.*/

namespace Replace
{
    [TestClass]
    public class ReplaceTests
    {
        [TestMethod]
        public void OneCharacter()
        {
            Assert.AreEqual("xyz", Replace("a", 'a', "xyz"));
        }

        [TestMethod]
        public void NoReplacement()
        {
            Assert.AreEqual("abc", Replace("abc", 'd', "xyz"));
        }

        [TestMethod]
        public void TwoDistinctCharacters()
        {
            Assert.AreEqual("axyz", Replace("ab", 'b', "xyz"));
        }

        string Replace(string initial, char toBeReplaced, string toInsert)
        {
            if (!initial.Contains(toBeReplaced.ToString()))
                return initial;          
            return  Replace(initial.Substring(0, initial.Length - 1) , toBeReplaced, toInsert) + toInsert;
        }
    }
}

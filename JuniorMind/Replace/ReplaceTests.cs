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
            Assert.AreEqual("aX", Replace("ad", 'd', "X"));
        }

        [TestMethod]
        public void MoreCharatersToBeRepplace()
        {
            Assert.AreEqual("XacXfgX", Replace("dacdfgd", 'd', "X"));
        }

        string Replace(string initial, char toBeReplaced, string toInsert)
        {
            if (initial == "")
                return initial;
            string lastCharacterRemoved = Replace(initial.Substring(0, initial.Length - 1), toBeReplaced, toInsert);
            return initial[initial.Length - 1] == toBeReplaced ? lastCharacterRemoved + toInsert : lastCharacterRemoved + initial[initial.Length - 1];              
        }
    }
}

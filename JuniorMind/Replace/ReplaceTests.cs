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

        string Replace(string given, char toBeReplaced, string toInsert)
        {
            if (!given.Contains(toBeReplaced.ToString()))
                return given;
            
            return  Replace(given.Substring(1, given.Length - 1) , toBeReplaced, toInsert) + toInsert;
        }
    }
}

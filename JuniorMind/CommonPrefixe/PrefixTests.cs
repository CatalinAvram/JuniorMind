using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//Dacă ai două stringuri, găsește-le prefixul comun. Exemplu: "aaab" și "aaaabbaa" au prefixul comun "aaa"
namespace CommonPrefixe
{
    [TestClass]
    public class PrefixesTests
    {
        [TestMethod]
        public void OneCommonLetter()
        {
            Assert.AreEqual("a", FindCommonPrefix("abba", "acca"));
        }
        string FindCommonPrefix(string firstString, string secondString)
        {
            string commonPrefix = "";
            for (int i = 0; i < firstString.Length; i++)
                if (firstString[i] == secondString[i])
                    commonPrefix += firstString[i];
                else
                    break;
            return commonPrefix;
        }
    }
}

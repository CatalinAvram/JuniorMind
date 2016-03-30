using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Convertește un număr dat, între 1 și 100, în cifre romane.
    I - 1
    V - 5
    X - 10
    L - 50
    C - 100
De ex:
    4 - IV
    8 - VIII
    9 - IX
    15 - XV
    30 - XXX
    39 - XXXIX
    41 - XLI
    45 - XLV
    99 - XCIX
*/
namespace RomanCiphers
{
    [TestClass]
    public class RomanCiphersTests
    {
        [TestMethod]
        public void CipherOne()
        {
            Assert.AreEqual("I", ConvertNumberFromArabicToRoman(1));
        }
        string ConvertNumberFromArabicToRoman(int arabicNumber)
        {
            if(arabicNumber == 1)
                return "I";
            return "";
        }
    }
}

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

        [TestMethod]
        public void CipherSeven()
        {
            Assert.AreEqual("VII", ConvertNumberFromArabicToRoman(7));
        }

        [TestMethod]
        public void RomanFourteen()
        {
            Assert.AreEqual("XIV", ConvertNumberFromArabicToRoman(14));    
        }

        [TestMethod]
        public void BetweenTwentyAndThirty()
        {
            Assert.AreEqual("XXV", ConvertNumberFromArabicToRoman(25));
        }

        [TestMethod]
        public void BetweenThirtyAndFourty()
        {
            Assert.AreEqual("XXXVII", ConvertNumberFromArabicToRoman(37));
        }

        [TestMethod]
        public void BetweenFourtyAndFifty()
        {
            Assert.AreEqual("XLV", ConvertNumberFromArabicToRoman(45));
        }
        string ConvertNumberFromArabicToRoman(int arabicNumber)
        {
            string[] oneToTenRomanCiphers = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};

            if (arabicNumber < 10)
                return oneToTenRomanCiphers[arabicNumber - 1];

            int arabicNumberFirstCipher = (int)Math.Floor((decimal)(arabicNumber / 10));
            string numberOfXes = new string('X', arabicNumberFirstCipher);
            if (arabicNumber >= 10 && arabicNumber < 40)
                return numberOfXes + oneToTenRomanCiphers[arabicNumber - (arabicNumberFirstCipher * 10 + 1)];

            if (arabicNumber == 40)
                return "XL";
            if (arabicNumber > 40 && arabicNumber < 50)
                return "XL" + oneToTenRomanCiphers[arabicNumber - 41];

          /*  if (arabicNumber >= 20 && arabicNumber < 30)
                return "XX" + oneToTenRomanCiphers[arabicNumber - 21];
            if (arabicNumber >= 30 && arabicNumber < 40)
                return "X" + oneToTenRomanCiphers[arabicNumber - 31];*/
            return "";
        }
    }
}

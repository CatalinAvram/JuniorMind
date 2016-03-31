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
        
        [TestMethod]
        public void BetweenFiftyAndEighty()
        {
            Assert.AreEqual("LXXXII", ConvertNumberFromArabicToRoman(82));
        }
        [TestMethod]
        public void BetweenNinetyAndOneHundred()
        {
            Assert.AreEqual("XCV", ConvertNumberFromArabicToRoman(95));
        }

        string ConvertNumberFromArabicToRoman(int arabicNumber)
        {
            string[] oneToTenRomanCiphers = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X"};

            if (arabicNumber < 10)
                return oneToTenRomanCiphers[arabicNumber - 1];
            int arabicNumberFirstCipher = (int)Math.Floor((decimal)(arabicNumber / 10));
            string numberOfXes = new string('X', arabicNumberFirstCipher);
            if (arabicNumber == 10)
                return numberOfXes;
            if (arabicNumber == 20)
                return numberOfXes;
            if (arabicNumber == 30)
                return numberOfXes;
            if (arabicNumber > 10 && arabicNumber < 40)
                return numberOfXes + oneToTenRomanCiphers[arabicNumber - (arabicNumberFirstCipher * 10 + 1)];

            if (arabicNumber == 40)
                return "XL";
            if (arabicNumber > 40 && arabicNumber < 50)
                return "XL" + oneToTenRomanCiphers[arabicNumber - 41];

            string numberOfXesForSecondSetNumbers = new string('X', arabicNumberFirstCipher - 5);
            if (arabicNumber == 50)
                return "L";
            if (arabicNumber == 60)
                return "LX";
            if (arabicNumber == 70)
                return "LXX";
            if (arabicNumber == 50)
                return "LXXX";
            if (arabicNumber > 50 && arabicNumber < 90)
                return "L" + numberOfXesForSecondSetNumbers + oneToTenRomanCiphers[arabicNumber - (arabicNumberFirstCipher * 10 + 1)];

            if (arabicNumber == 90)
                return "XC";
            if (arabicNumber == 100) 
                return "C";
            if (arabicNumber > 90 && arabicNumber < 100)
                return "XC" + oneToTenRomanCiphers[arabicNumber - (arabicNumberFirstCipher * 10 + 1)];
            return "";
        }
    }
}

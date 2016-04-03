using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Primele 26 de coloane din Excel sunt marcate cu literele alfabetului.
După care continuă cu combinații de câte două litere, astfel coloana 27 este AA, 28 - AB, iar coloana 52 cu AZ.
După ZZ, se continuă cu combinații de 3 litere.

Dacă se dă numărul coloanei află care e combinația de litere corespunzătoare.*/
namespace ExcelColumns
{
    [TestClass]
    public class ExcelTests
    {
        [TestMethod]
        public void OneLetterName()
        {
            Assert.AreEqual("C", GiveColumnCorrespondingString(3));
        }

        [TestMethod]
        public void TwoLettersName()
        {
            Assert.AreEqual("BA", GiveColumnCorrespondingString(52));
        }

        [TestMethod]
        public void FactorialNumber()
        {
            Assert.AreEqual(120, ComputeFactorialNumber(5));
        }

        string GiveColumnCorrespondingString (int columnNumber)
        {
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                 "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            if (columnNumber <= 26)
                return letters[columnNumber - 1];       
            else
                return "";
        } 

        int ComputeFactorialNumber(int number)
        {
            if (number == 0)
                return 1;

            int factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial *= i;
            return factorial;
        }
    }
}

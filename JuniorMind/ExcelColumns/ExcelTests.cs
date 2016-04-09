﻿using System;
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
            Assert.AreEqual("AB", GiveColumnCorrespondingString(28));
        }

        string GiveColumnCorrespondingString(int columnNumber)
        {          
            string columnString = "";
            while(columnNumber > 0)
            {
                columnNumber--;
                columnString = (char)('A' + columnNumber % 26) + columnString;
                columnNumber /= 26;
            }
            return columnString;
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Scrie un program care imită un calculator de buzunar în formă prefixată.
Operațiile posibile sunt:
    adunare/scădere
    înmulțire/împărțire
    suportă numere reale
Notă: În forma prefixată operatorii apar înaintea operanzilor.
Exemple pentru format prefixată:
    * 3 4 e echivalent cu 3 * 4
    * + 1 1 2, e echivalent cu (1 + 1) * 2
    + / * + 56 45 46 3 - 1 0.25 e echivalent cu ((56 + 45) * 46) / 3 + (1 - 0.25)*/
namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void OneOperand()
        {
            Assert.AreEqual(7, Calculate( "+, 3, 4", 0));
        }

        double Calculate(string expression, int  i)
        {
            string[] expressionElements = expression.Split(',');
            double result;

            if (double.TryParse(expressionElements[i], out result))
                return result;
            return SelectOperation(expression, expressionElements, i);
        }

        private double SelectOperation(string expression, string[] expressionElements, int i)
        {
            if(expressionElements[i] == "+")                           
                return Calculate(expressionElements[i + 1], i) + Calculate(expressionElements[i + 2], i);
            return 0;
        }

    }
}

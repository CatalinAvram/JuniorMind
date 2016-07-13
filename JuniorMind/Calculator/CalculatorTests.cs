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
        public void OneOperator()
        {
            int i = 0;
            Assert.AreEqual(7, Calculate(" +, 3, 4", ref i));
        }

        [TestMethod]
        public void TwoOperators()
        {
            int i = 0;
            Assert.AreEqual(4, Calculate(" *, +, 1, 1, 2",  ref i));
        }

        double Calculate(string expression, ref int i)
        {
            string[] expressionElements = expression.Split(',');
            var current = expressionElements[i++];
            double result;

            if (Double.TryParse(current, out result))
                return result;
            return SelectOperation(expression, current, ref i);
        }

        double SelectOperation(string expression, string current, ref int i)
        {
            switch (current)
            {
                case " +":
                    return Calculate(expression, ref i) + Calculate(expression, ref i);
                case " -":
                    return Calculate(expression, ref i) - Calculate(expression, ref i);
                case " *":
                    return Calculate(expression, ref i) * Calculate(expression, ref i);
                default:
                    return Calculate(expression, ref i) / Calculate(expression, ref i);
            }
        }

    }
}

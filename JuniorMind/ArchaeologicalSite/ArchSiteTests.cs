using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Într-un sit arheologic s-au descoperit 3 coloane care aparțineau unei clădiri. dacă se dau coordonatele celor 3 coloane,
află aria minimă a clădirii. Coordonatele sunt numere cu 6 zecimale.*/

namespace ArchaeologicalSite
{
    [TestClass]
    public class ArchSiteTests
    {
        [TestMethod]
        public void MinArea()
        {
            Assert.AreEqual(2, CalculateMinimumArea(0, 0, 2, 0, 1, 2));
        }
        double CalculateMinimumArea(double firstColumnX, double firstColumnY, double secondColumnX, double secondColumnY, double thirdColumnX, double thirdColumnY)
        {
            double side1 = Math.Sqrt(Math.Pow(firstColumnX - secondColumnX, 2) + Math.Pow(firstColumnY - secondColumnY, 2));
            double side2 = Math.Sqrt(Math.Pow(firstColumnX - thirdColumnX, 2) + Math.Pow(firstColumnY - thirdColumnY, 2));
            double side3 = Math.Sqrt(Math.Pow(secondColumnX - thirdColumnX, 2) + Math.Pow(secondColumnY - thirdColumnY, 2));
            double perimeter = (side1 + side2 + side3) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - side1) * (perimeter - side2) * (perimeter - side3));

            return area;
        }
    }
}

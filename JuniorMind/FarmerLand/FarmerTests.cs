using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Un fermier are un teren pătrat. Pentru a-și extinde suprafața a mai cumpărat o parcelă alăturată.
Noua parcelă are acceași lungime și are o lățime de 230m. Acum fermierul are un teren de 77ha (770.000mp).

Ce dimensiune avea inițial terenul*/
namespace FarmerLand
{
    [TestClass]
    public class FarmerTests
    {
        [TestMethod]
        public void initialArea()
        {
            Assert.AreEqual(1000000, CalculateInitialArea(230, 770000));
        }
        double CalculateInitialArea(double secondLandWidth, double finalArea)
        {
            double delta = Math.Pow(secondLandWidth, 2) + 4 * finalArea;
            double length = (secondLandWidth + Math.Sqrt(delta)) / 2;
            double initialLandArea = Math.Pow(length, 2);
            return initialLandArea;
        }
    }
}

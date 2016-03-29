using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Ai de plătit chiria lunară. Dar cu fiecare zi de întârziere trebuie să plătești o penalitate.
Dacă ai întârziat:
    1-10 zile - plătești o penalitate de 2% din chirie/zi întârzire
    11-30 zile - plătești o penalitate de 5% din chirie/zi întârzire
    31-40 zile - plătești o penalitate de 10% din chirie/zi întârzire
Dacă ști chiria și numărul de zile de întârziere, calculează suma totală de plată.*/

namespace Debt
{
    [TestClass]
    public class DebtTests
    {
        [TestMethod]
        public void SmallDelayRent()
        {
            Assert.AreEqual(110, CalculateDebt(100, 5));
        }
        
        decimal CalculateDebt(decimal rent, int delayDays)
        {
            if (delayDays >= 1 && delayDays < 11)
                return rent + 2 / 100 * rent * delayDays;
            else
                return 0;
        }
    }
}

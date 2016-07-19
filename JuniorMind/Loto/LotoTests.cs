using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loto
{
    [TestClass]
    public class LotoTests
    {
        [TestMethod]
        public void SixNumbersSet()
        {
            GetSortNumbersOutput SortNumbers = null;
            LotoSort ob = new LotoSort();
            SortNumbers = new GetSortNumbersOutput(ob.SortNumbersOutput);           
            int[] drawnNumbers = new int[] { 22, 31, 4, 9, 48, 28 };
            CollectionAssert.AreEqual(new int[] { 4, 9, 22, 28, 31, 48 }, SortNumbers(drawnNumbers));
        }
    }
}

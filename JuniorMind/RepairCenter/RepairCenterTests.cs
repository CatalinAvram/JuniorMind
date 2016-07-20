using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*La un centru de reparații fiecare caz are o prioritate: High, Medium și Low.
Ordonează cazurile în funcție de prioritate.*/
namespace RepairCenter
{
    [TestClass]
    public class RepairCenterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            SortCases ob = new SortCases();
            Car[] carsToBeSorted = new Car[3];
            for (int i = 0; i < carsToBeSorted.Length; i++)
            {
                carsToBeSorted[i] = new Car();
            }
            carsToBeSorted[0].Priority = "Medium";
            carsToBeSorted[1].Priority = "High";
            carsToBeSorted[2].Priority = "Low";
            CollectionAssert.AreEqual(new Car[] { carsToBeSorted[1], carsToBeSorted[0], carsToBeSorted[2] }, ob.SortAfterPriority(carsToBeSorted));
        }
    }
}

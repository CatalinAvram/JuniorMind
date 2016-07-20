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
        public void TestForThreeCars()
        {
            SortCases ob = new SortCases();
            Car[] carsToBeSorted = new Car[3];
            for (int i = 0; i < carsToBeSorted.Length; i++)
            {
                carsToBeSorted[i] = new Car();
            }
            carsToBeSorted[0].Priority = "Medium";
            carsToBeSorted[0].Name = "Honda";
            carsToBeSorted[1].Priority = "High";
            carsToBeSorted[1].Name = "Dacia";
            carsToBeSorted[2].Priority = "Low";
            carsToBeSorted[2].Name = "Ferrari";

            CollectionAssert.AreEqual(new string[] { "Dacia", "Honda", "Ferrari" }, ob.SortAfterPriority(carsToBeSorted));
        }
    }
}

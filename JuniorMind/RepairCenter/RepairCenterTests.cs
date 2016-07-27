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
        public void SimpleTest()
        {
            Priority[] priorities = new Priority[] { Priority.Low, Priority.Medium, Priority.High };
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, ShowCorrectOrder(priorities));
        }

        public int[] ShowCorrectOrder(Priority[] priorities)
        {
            Car[] carsToBeRepaired = new Car[priorities.Length];
            for(int i = 0; i < carsToBeRepaired.Length; i++)
            {
                carsToBeRepaired[i] = new Car(priorities[i]);
            }

            Administrator admin = new Administrator(carsToBeRepaired);
            admin.addArrivalNumber();
            return admin.SortAfterPriorities();       
        }
    }
}

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

        [TestMethod]
        public void EqualPriorities()
        {
            Priority[] priorities = new Priority[] { Priority.High, Priority.High, Priority.High };
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, ShowCorrectOrder(priorities));
        }

        [TestMethod]
        public void MoreComplexCase()
        {
            Priority[] priorities = new Priority[] { Priority.High, Priority.Medium, Priority.Low, Priority.Medium, Priority.Low };
            CollectionAssert.AreEqual(new int[] { 1, 2, 4, 3, 5 }, ShowCorrectOrder(priorities));
        }

        public int[] ShowCorrectOrder(Priority[] priorities)
        {
            Car[] carsToBeRepaired = new Car[priorities.Length];
            for(int i = 0; i < carsToBeRepaired.Length; i++)
            {
                carsToBeRepaired[i] = new Car(priorities[i]);
            }

            Administrator admin = new Administrator(carsToBeRepaired);
            int[] carsOrder = new int[priorities.Length];
            admin.AddArrivalNumber();
            admin.SortAfterPriorities();

            for (int i = 0; i < carsOrder.Length; i++)
                carsOrder[i] = admin.GetNextCar();
            return carsOrder;            
        }
    }
}

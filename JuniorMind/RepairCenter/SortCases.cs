using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/*La un centru de reparații fiecare caz are o prioritate: High, Medium și Low.
Ordonează cazurile în funcție de prioritate.*/
namespace RepairCenter
{
    public class SortCases
    {
        public Car[] SortAfterPriority(Car[] carsToBeSorted)
        {
            Car carObject = new Car();
            //int[] finalOrder = new int[carsToBeSorted.Length];
            string priorities = "HighMediumLow";    
             
            for(int i = 0; i <= carsToBeSorted.Length - 1; i++)
                for(int j = i + 1; j < carsToBeSorted.Length; j++)
                {
                    if (priorities.IndexOf(carsToBeSorted[i].Priority) > priorities.IndexOf(carsToBeSorted[j].Priority))
                    {
                        carObject = carsToBeSorted[i];
                        carsToBeSorted[i] = carsToBeSorted[j];
                        carsToBeSorted[j] = carObject;
                    }                       
                }
            return carsToBeSorted;                               
        }
    }

    public class Car
    {
        private string priority;
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }                 
    }
}

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
        public string[] SortAfterPriority(Car[] carsToBeSorted)
        {
            Car carObject = new Car();
            string[] priorities = new string[] { "High", "Medium", "Low" };
            string[] carName = new string[carsToBeSorted.Length];

            for (int i = 0; i <= carsToBeSorted.Length - 1; i++)
            {
                for (int j = i + 1; j < carsToBeSorted.Length; j++)
                {
                    if (Array.IndexOf(priorities, carsToBeSorted[i].Priority) > Array.IndexOf(priorities, carsToBeSorted[j].Priority))
                    {
                        carObject = carsToBeSorted[i];
                        carsToBeSorted[i] = carsToBeSorted[j];
                        carsToBeSorted[j] = carObject;
                    }
                }
                carName[i] = carsToBeSorted[i].Name;
            }
            return carName;                               
        }
    }

    public class Car
    {
        private string priority;
        private string name;

        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }             
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }    
    }
}

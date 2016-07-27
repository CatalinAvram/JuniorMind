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
    public class Administrator
    {
        private Car[] carsToBeRepaired;
        private int[] arrivalNumber;

        public Administrator(Car[] carsToBeRepaired)
        {
            this.carsToBeRepaired = carsToBeRepaired;
            arrivalNumber = new int[carsToBeRepaired.Length];
        }

        public void addArrivalNumber()
        {
            for (int i = 0; i < carsToBeRepaired.Length; i++)
            {
                arrivalNumber[i] = i + 1;
            }
        }

        public int[] SortAfterPriorities()
        {           
            for (int i = 0; i < carsToBeRepaired.Length - 1; i++)
            {
                for (int j = i + 1; j < carsToBeRepaired.Length; j++)
                {
                    if (carsToBeRepaired[i].Priority < carsToBeRepaired[j].Priority)
                    {
                        int temp = arrivalNumber[i];
                        arrivalNumber[i] = arrivalNumber[j];
                        arrivalNumber[j] = temp;
                    }
                }
            }
            return arrivalNumber;
        }
    }
}

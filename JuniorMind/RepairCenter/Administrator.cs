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
    class Administrator
    {
        private Car[] carsToBeRepaired;
        private int[] arrivalNumber;

        public Administrator(Car[] carsToBeRepaired)
        {
            this.carsToBeRepaired = carsToBeRepaired;
            arrivalNumber = new int[carsToBeRepaired.Length];
        }

        public void AddArrivalNumber()
        {
            for (int i = 0; i < carsToBeRepaired.Length; i++)
            {
                arrivalNumber[i] = i + 1;
           } 
        }

        public void Swap <T> (ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }

        public void SortAfterPriorities()
        {
            for (int i = 0; i < carsToBeRepaired.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (carsToBeRepaired[j - 1].Priority >= carsToBeRepaired[j].Priority)
                    {
                        Swap(ref carsToBeRepaired[j - 1], ref carsToBeRepaired[j]);
                        Swap(ref arrivalNumber[j - 1], ref arrivalNumber[j]);                 
                    }
                }
            }
        }

        public int GetNextCar()
        {
            int nextCarNumber = arrivalNumber[arrivalNumber.Length - 1];
            Array.Resize(ref arrivalNumber, arrivalNumber.Length - 1);
            return nextCarNumber;
        }
    }
}

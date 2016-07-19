using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Trebuie ca tot timpul numerele extrase la loto să fie afișate la public în ordine crescătoare
și nu în ordinea în care au fost extrase.
Scrie o funcție care face asta.*/
namespace Loto
{
    public delegate int[] GetSortNumbersOutput(int[] drawnNumbers);

    class LotoSort
    {
        private int[] SortNumbers(int[] drawnNumbers)
        {
            for (int i = 0; i < drawnNumbers.Length - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (drawnNumbers[j - 1] > drawnNumbers[j])
                    {
                        int aux = drawnNumbers[j - 1];
                        drawnNumbers[j - 1] = drawnNumbers[j];
                        drawnNumbers[j] = aux;
                    }
                    j--;
                }
            }
            return drawnNumbers;
        }
            
        public GetSortNumbersOutput SortNumbersOutput
        {
            get
            {
                return new GetSortNumbersOutput(SortNumbers);
            }
        }
    }
}

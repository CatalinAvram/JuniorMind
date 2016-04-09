using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Un om de știință vrea să știe toate numerele al căror cub se termină cu 888.
Ajută-l prin a-i face un program care pentru numărul k, întoarce al k-lea număr al cărui cub e 888.

Exemplu: dacă k e 1, rezultatul e 192*/
namespace Cube
{
    [TestClass]
    public class CubeTests
    {
        [TestMethod]
        public void FirstNumber()
        {
        }

        {
            
            int counter = 0;
            int cube = 1;

            while(counter < k)
            {
                number++;                   
                cube = (int)Math.Pow(number, 3);
                if (cube % 1000 == 888)
                    counter++;
            }
            return number;
        }
    }
}

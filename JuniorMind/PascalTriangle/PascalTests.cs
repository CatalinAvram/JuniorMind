using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Generează triunchiul lui Pascal pentru un nivel dat folosindu-te de recursivitate.
Triunghiul lui Pascal:
                            1
                       1        1
                   1        2       1
               1       3       3       1
           1       4        6      4      1
        1       5       10      10      5     1
     1     6       15       20      15      6     1*/
namespace PascalTriangle
{
    [TestClass]
    public class PascalTests
    {
        [TestMethod]
        public void FirstLevel()
        {
            CollectionAssert.AreEqual(new int[] { 1 }, GeneratePascalTriangle(1));
        }

        [TestMethod]
        public void SecondLevel()
        {
            CollectionAssert.AreEqual(new int[] { 1, 1, 1 }, GeneratePascalTriangle(2));
        }

        int[] GeneratePascalTriangle(int level)
        {            
            if(level < 2)
            {
                return new int[] { 1 };
            }

            int[] triangleElements = new int[0];
            int k = 0;
            for (int i = 0; i < level; i++)
                for (int j = 0; j <= i; j++)
                {
                    Array.Resize(ref triangleElements, triangleElements.Length + 1);
                    triangleElements[k] = ComputeCombinations(i, j);
                    k++;
                }
            return triangleElements;
        }

        int ComputeFactorial(int n)
        {
            if (n < 2)
                return 1;          
            return n * ComputeFactorial(n - 1); 
        }

        int ComputeCombinations(int n, int k)
        {
            return ComputeFactorial(n) / (ComputeFactorial(k) * ComputeFactorial(n - k));
        }
    }
}

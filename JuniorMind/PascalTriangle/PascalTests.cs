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
            CollectionAssert.AreEqual(new int[] { 1, 1 }, GeneratePascalTriangle(2));
        }

        [TestMethod]
        public void ThirdLevel()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 1 }, GeneratePascalTriangle(3));
        }

        int[] GeneratePascalTriangle(int level)
        {            
            if(level < 2)
            {
                return new int[] { 1 };
            }

            int[] triangleElements = new int[level];
            int i = 0;
            for (int k = 0; k < level; k++)
                {
                    triangleElements[i] = ComputeFactorial(level - 1) / (ComputeFactorial(k) * ComputeFactorial(level - 1 - k));  
                    i++;
                }
            return triangleElements;
        }

        int ComputeFactorial(int n)
        {
            if (n < 2)
                return 1;          
            return n * ComputeFactorial(n - 1); 
        }      
    }
}

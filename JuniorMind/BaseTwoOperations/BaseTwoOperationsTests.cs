using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Ai un număr zecimal transformă-l în baza doi, reprezentat ca și un array de byte (byte[]).
Pentru un număr transformat implementează operațiile:
    NOT, AND, NOT, OR, XOR
    RightHandShift și LeftHandShift (shiftare de biți la dreapta și la stânga)
    LessThan
    Adunare și scădere
    Înmulțire și împărțire
    Folosește-te de LessThan pentru a implementa și alți operatori de comparare (GraterThan, Equal, NotEqual)
Doar pentru numere pozitive.
Poți generaliza transformarea și operațiile de la 3-6 pentru o bază aleatoare (baza fiind între 2 și 255)?*/

namespace BaseTwoOperations
{
    [TestClass]
    public class BaseTwoOperationsTests
    {
        [TestMethod]
        public void ACipher()
        {
            byte[] binaryArray = { 1, 0, 0 };
            CollectionAssert.AreEqual(binaryArray, ConvertToBaseTwo(4));
        }

        [TestMethod]
        public void TestForTwelve()
        {
            byte[] binaryArray = {  1, 1, 0, 0 };
            CollectionAssert.AreEqual(binaryArray, ConvertToBaseTwo(12));
        }

        [TestMethod]
        public void FortyNine()
        {
            byte[] binaryArray = { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(binaryArray, ConvertToBaseTwo(49));
        }

        [TestMethod]
        public void NumberOfBinaryDigits()
        {
            Assert.AreEqual(3, GetNumberOfBinaryDigits(4));
        }

        [TestMethod]
        public void TestNOTOperator()
        {
            byte[] binaryArray = { 0, 1, 1 };
            CollectionAssert.AreEqual(binaryArray, ApplyNotOperator(ConvertToBaseTwo(4)));
        }

        [TestMethod]
        public void ANDForEqualLengthBinaryNumbers()
        {         
            CollectionAssert.AreEqual(ConvertToBaseTwo(5 & 4), ApplyAndOperator(ConvertToBaseTwo(5), ConvertToBaseTwo(4)));
        }

        [TestMethod]
        public void ANDForDifferentLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ConvertToBaseTwo(5 & 3), ApplyAndOperator(ConvertToBaseTwo(5), ConvertToBaseTwo(3)));
        }
        
        byte[] ConvertToBaseTwo(int decimalNumber)
        {
            int decimalNumberCopy = decimalNumber;
            int length = GetNumberOfBinaryDigits(decimalNumberCopy);

            byte[] binaryNumber = new byte[length];        
            for (int position = length - 1; position >= 0; position--)
            {
                binaryNumber[position] = (byte)(decimalNumber % 2);
                decimalNumber = decimalNumber / 2;      
            }
            return binaryNumber;
        }

        private static int GetNumberOfBinaryDigits(int number)
        {
            int length = 0;
            while (number > 0)
            { 
                number /= 2;
                length++;
            }
            return length;
        }

        byte[] ApplyNotOperator(byte[] binaryArray)
        {
             
            for(int i = 0; i < binaryArray.Length; i++)
            {
                if (binaryArray[i] == 0)
                    binaryArray[i] = 1;
                else
                    binaryArray[i] = 0;
            }
            return binaryArray;
        }

        byte[] ApplyAndOperator(byte[] binaryArray1, byte[] binaryArray2)
        {
            int k = Math.Min(binaryArray1.Length, binaryArray2.Length);
            byte[] binaryArray = new byte[k];           
            int i = binaryArray1.Length;
            int j = binaryArray2.Length;

            while(k > 0)
            {
                k--;
                i--;
                j--;
                if (binaryArray1[i] == 0 && binaryArray2[j] == 0)
                    binaryArray[k] = 0;
                else
                    binaryArray[k] = (byte)(binaryArray1[i] + binaryArray2[j] - 1);               
            }
            return binaryArray;
        }
    }
}

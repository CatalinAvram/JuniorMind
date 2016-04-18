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
        public void StringOfBinaryDigits()
        {
            Assert.AreEqual("100", GetStringOfBinaryDigits(4));
        }

        [TestMethod]
        public void TestNotOperator()
        {
            byte[] binaryArray = { 0, 1, 1 };
            CollectionAssert.AreEqual(binaryArray, ApplyNotOperator(4));
        }
      
        byte[] ConvertToBaseTwo(int decimalNumber)
        {        
            string binaryString = GetStringOfBinaryDigits(decimalNumber);
            int length = binaryString.Length;        
            byte[] binaryNumber = new byte[length];

            for (int position = length - 1; position >= 0; position--)
            {
                binaryNumber[position] = byte.Parse(binaryString[position].ToString());               
            }
          
            return binaryNumber;
        }

        private static string GetStringOfBinaryDigits(int number)
        {
            string binaryDigitsString = "";
            while (number > 0)
            {
                binaryDigitsString = number % 2 + binaryDigitsString;
                number /= 2;
            }
            return binaryDigitsString;
        }

        byte[] ApplyNotOperator(int number)
        {
            byte[] binaryNumber = ConvertToBaseTwo(number); 
            for(int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == 0)
                    binaryNumber[i] = 1;
                else
                    binaryNumber[i] = 0;
            }
            return binaryNumber;
        }
    }
}

﻿using System;
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
            CollectionAssert.AreEqual(binaryArray, ToBinary(4));
        }

        [TestMethod]
        public void TestForTwelve()
        {
            byte[] binaryArray = {  1, 1, 0, 0 };
            CollectionAssert.AreEqual(binaryArray, ToBinary(12));
        }

        [TestMethod]
        public void FortyNine()
        {
            byte[] binaryArray = { 1, 1, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(binaryArray, ToBinary(49));
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
            CollectionAssert.AreEqual(binaryArray, Not(ToBinary(4)));
        }
          
        [TestMethod]
        public void ElementFromGivenPosition()
        {
            byte[] array = { 1, 2, 3 };
            Assert.AreEqual(3, GetAt(array, 0));
        }

        [TestMethod]
        public void PositionNotInTheArray()
        {
            byte[] array = { 1, 2, 3 };
            Assert.AreEqual(0, GetAt(array, 4));
        }

        [TestMethod]
        public void NumberOfZeroes()
        {
            Assert.AreEqual(3, CountZeroes(ToBinary(8)));
        }

        [TestMethod]
        public void OnlyZeroes()
        {
            Assert.AreEqual(1, CountZeroes(ToBinary(0)));
        }

        [TestMethod]
        public void ANDOnlyZeroes()
        {
            CollectionAssert.AreEqual(new byte[] { 0 }, And(ToBinary(4), ToBinary(3)));
        }

        [TestMethod]
        public void ANDForEqualLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ToBinary(5 & 4), And(ToBinary(5), ToBinary(4)));
        }

        [TestMethod]
        public void ANDForDifferentLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ToBinary(5 & 9), And(ToBinary(5), ToBinary(9)));
        }

        byte[] ToBinary(int decimalNumber)
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

        byte[] Not(byte[] binaryArray)
        {          
            for(int i = 0; i < binaryArray.Length; i++)
            {               
               binaryArray[i] = (byte)(binaryArray[i] == 0 ? 1 : 0);
            }        
            return binaryArray;
        }

        byte[] And(byte[] first, byte[] second)
        {
            byte[] number = new byte[Math.Max(first.Length, second.Length)];
            for (int i = Math.Max(first.Length, second.Length) - 1; i >= 0; i--)
            {
                if (GetAt(first, i) == 1 && GetAt(second, i) == 1)
                    number[i] = 1;
                else
                    number[i] = 0;
            }
            if (CountZeroes(number) == 1)
                return new byte[] { 0 };
            
            return RemoveTrailingZeroes(number); ;
        }

        private byte[] RemoveTrailingZeroes(byte[] number)
        {
            Array.Resize(ref number, number.Length - CountZeroes(number));
            Array.Reverse(number);
            return number;
        }

        byte GetAt(byte[] binaryArray, int position)
        {
            if(position < binaryArray.Length)
                return binaryArray[binaryArray.Length - position - 1];
            return 0;
        }  
        
        int CountZeroes(byte[] number)
        {
            for(int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] != 0)
                    return number.Length - i - 1;
            }
            return 1;
        }                    
    }
}

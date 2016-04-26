using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Ai un număr zecimal transformă-l în baza doi, reprezentat ca și un array de byte (byte[]).
Pentru un număr transformat implementează operațiile:
    NOT, AND, NOT, OR, XOR
    RightHandShift și LeftHandShift (shiftare de biți la dreapta și la stânga)
    LessThan
    Adunare și scădere
    Înmulțire și împărțire
    Folosește-te de LessThan pentru a implementa și alți operatori de comparare (GreaterThan, Equal, NotEqual)
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
        public void ZeroToBinary()
        {
            CollectionAssert.AreEqual(new byte[] { 0 }, ToBinary(0));
        }

        [TestMethod]
        public void TestForTwelve()
        {
            byte[] binaryArray = { 1, 1, 0, 0 };
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
        public void TrailingZero()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, RemoveTrailingZeroes(new byte[] { 1, 1, 0 }));
        }

        [TestMethod]
        public void ANDOnlyZeroes()
        {
            CollectionAssert.AreEqual(new byte[] { 0 }, LogicOperations(ToBinary(4), ToBinary(3), "AND"));
        }

        [TestMethod]
        public void ANDForEqualLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ToBinary(5 & 4), LogicOperations(ToBinary(5), ToBinary(4), "AND"));
        }

        [TestMethod]
        public void ANDForDifferentLengthBinaryNumbers()
        {
            CollectionAssert.AreEqual(ToBinary(5 & 9), LogicOperations(ToBinary(5), ToBinary(9), "AND"));
        }

        [TestMethod]
        public void ORForDifferentLegth()
        {
            CollectionAssert.AreEqual(ToBinary(5 | 9), LogicOperations(ToBinary(5), ToBinary(9), "OR"));
        }

        [TestMethod]
        public void ORForEqualLength()
        {
            CollectionAssert.AreEqual(ToBinary(5 | 4), LogicOperations(ToBinary(5), ToBinary(4), "OR"));
        }

        [TestMethod]
        public void XORForEqualLength()
        {
            CollectionAssert.AreEqual(ToBinary(5 ^ 4), LogicOperations(ToBinary(5), ToBinary(4), "XOR"));
        }

        [TestMethod]
        public void XORForDifferentLegth()
        {
            CollectionAssert.AreEqual(ToBinary(5 ^ 9), LogicOperations(ToBinary(5), ToBinary(9), "XOR"));
        }

        [TestMethod]
        public void And()
        {
            Assert.AreEqual(0, And(0, 1));
        }

        [TestMethod]
        public void Or()
        {
            Assert.AreEqual(1, Or(1, 0));
        }

        [TestMethod]
        public void Xor()
        {
            Assert.AreEqual(0, Xor(1, 1));
        }

        [TestMethod]
        public void LogicOperationSelection()
        {
            Assert.AreEqual(0, SelectLogicOperation(1, 1, "XOR"));
        }

        [TestMethod]
        public void RightShift()
        {
            CollectionAssert.AreEqual(ToBinary(5 >> 3), RightHandShift(ToBinary(5), 3));
        }

        [TestMethod]
        public void PositionsBiggerThanLength()
        {
            CollectionAssert.AreEqual(ToBinary(3 >> 5), RightHandShift(ToBinary(3), 5));
        }

        [TestMethod]
        public void LeftShift()
        {
            CollectionAssert.AreEqual(ToBinary(5 << 2), LeftHandShift(ToBinary(5), 2));
        }

        [TestMethod]
        public void LeftShiftForZero()
        {
            CollectionAssert.AreEqual(ToBinary(0 << 5), LeftHandShift(ToBinary(0), 5));
        }

        [TestMethod]
        public void LessThanCheck()
        {
            Assert.AreEqual(false, LessThan(ToBinary(8), ToBinary(4)));
        }

        [TestMethod]
        public void LessThanEqualLengths()
        {
            Assert.AreEqual(true, LessThan(ToBinary(4), ToBinary(5)));
        }

        [TestMethod]
        public void LessThanForEqualNumbers()
        {
            Assert.AreEqual(false, LessThan(ToBinary(5), ToBinary(5)));
        }

        [TestMethod]
        public void GreaterThanCheck()
        {
            Assert.AreEqual(true, GreaterThan(ToBinary(5), ToBinary(4)));
        }

        [TestMethod]
        public void EqualOperator()
        {
            Assert.AreEqual(true, Equal(ToBinary(5), ToBinary(5)));
        }

        [TestMethod]
        public void NotEqualOpeator()
        {
            Assert.AreEqual(true, NotEqual(ToBinary(5), ToBinary(6)));
        }

        [TestMethod]
        public void SumWithoutExtraBit()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, Sum(ToBinary(3), ToBinary(4)));
        }

        [TestMethod]
        public void SumWithExtraBitNeeded()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 0 }, Sum(ToBinary(3), ToBinary(5)));
        }

        [TestMethod]
        public void DifferenceWithoutZeroInFront()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0 }, Difference(ToBinary(7), ToBinary(1)));
        }

        [TestMethod]
        public void DifferenceBetweenSixAndThree()
        {
            CollectionAssert.AreEqual(new byte[] {0, 1, 1 }, Difference(ToBinary(6), ToBinary(3)));
        }

        [TestMethod]
        public void DifferenceWithMultipleZeroesInFront()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 1, 1, 1, 0, 1 }, Difference(ToBinary(142), ToBinary(113)));
        }

        byte[] ToBinary(int decimalNumber)
        {
            if (decimalNumber == 0)
                return new byte[] { 0 };

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
            for (int i = 0; i < binaryArray.Length; i++)
            {
                binaryArray[i] = (byte)(binaryArray[i] == 0 ? 1 : 0);
            }
            return binaryArray;
        }

        byte[] LogicOperations(byte[] first, byte[] second, string operation)
        {
            byte[] resultedNumber = new byte[Math.Max(first.Length, second.Length)];
            byte firstBit = 0;
            byte secondBit = 0;
            for (int i = Math.Max(first.Length, second.Length) - 1; i >= 0; i--)
            {
                firstBit = GetAt(first, i);
                secondBit = GetAt(second, i);
                resultedNumber[i] = SelectLogicOperation(firstBit, secondBit, operation);
            }          
            return RemoveTrailingZeroes(resultedNumber);
        }

        byte SelectLogicOperation(byte firstBit, byte secondBit, string operation)
        {
            switch (operation)
            {
                case "AND":
                    return And(firstBit, secondBit);
                case "OR":
                    return Or(firstBit, secondBit);
                case "XOR":
                    return Xor(firstBit, secondBit);              
            }
            return 0;
        }

        byte And(byte firstBit, byte secondBit)
        {
            if (firstBit == 1 && secondBit == 1)
                return 1;
            return 0;
        }

        byte Or(byte firstBit, byte secondBit)
        {
            if (firstBit == 1 || secondBit == 1)
                return 1;
            return 0;
        }

        byte Xor(byte firstBit, byte secondBit)
        {
            if (firstBit != secondBit)
                return 1;
            return 0;
        }

        byte GetAt(byte[] binaryArray, int position)
        {
            if (position >= 0 && position < binaryArray.Length)
                return binaryArray[binaryArray.Length - position - 1];
            return 0;
        }

        private byte[] RemoveTrailingZeroes(byte[] number)
        {
            if (CountZeroes(number) == number.Length)
                return new byte[] { 0 };         
            Array.Resize(ref number, number.Length - CountZeroes(number));
            Array.Reverse(number);
            return number;
        }

        int CountZeroes(byte[] number)
        {                                   
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] != 0)
                    return number.Length - i - 1;
            }
            return number.Length;
        }    

        byte[] RightHandShift(byte[] number, int numberOfPositions)
        {
            if (numberOfPositions >= number.Length)
                return new byte[] { 0 };
            Array.Resize(ref number, number.Length - numberOfPositions);           
            return number;
        }
        
        byte[] LeftHandShift(byte[] number, int numberOfPositions)
        {
            if (number.Length == 1 && number[0] == 0)
                return new byte[] { 0 };          
            Array.Resize(ref number, number.Length + numberOfPositions);
            return number;
        }

        bool LessThan(byte[] first, byte[] second)
        {
            for (int i = Math.Max(first.Length, second.Length) - 1; i >= 0; i--)
            {
                if (GetAt(first, i) != GetAt(second, i))
                    return GetAt(first, i) < GetAt(second, i);
            }                             
            return false;
        }

        bool GreaterThan(byte[] first, byte[] second)
        {
            if (!LessThan(first, second) && !Equal(first, second))
                return true;
            return false;
        }

        bool Equal(byte[] first, byte[] second)
        {
            if (first.Length == second.Length && CountZeroes(first) == CountZeroes(second))
                return true;
            return false;
        }
        
        bool NotEqual(byte[] first, byte[] second) {
            if (!Equal(first, second))
                return true;
            return false;
        }

        byte[] Sum(byte[] first, byte[] second)
        {
            byte[] result = new byte[Math.Max(first.Length, second.Length)];
            int position = 0;
            int transport = 0;
            for(int i = Math.Max(first.Length, second.Length) - 1; i >= 0 ; i--)
            {
                if ((byte)(GetAt(first, position) + GetAt(second, position)) + transport > 1)
                {
                    result[i] = 0;
                    transport = 1;
                }
                else
                    result[i] = (byte)(GetAt(first, position) + GetAt(second, position));
                position++;
            }

            if (transport == 1)
            {
                result = PutExtraBit(result, transport);
            }
            return result;
        }

        private static byte[] PutExtraBit(byte[] result, int transport)
        {
            Array.Reverse(result);
            Array.Resize(ref result, result.Length + 1);
            Array.Reverse(result);
            result[0] = (byte)transport;

            return result;
        }

        byte[] Difference(byte[] first, byte[] second)
        {
            byte[] result = new byte[Math.Max(first.Length, second.Length)];
            for (int i = 0; i < Math.Max(first.Length, second.Length); i++)
            {
                if (GetAt(first, i) == GetAt(second, i) || (GetAt(first, i) == 1))
                    result[i] = (byte)(GetAt(first, i) - GetAt(second, i));
                else
                {
                    if (GetAt(first, i) == 0)
                    {
                        result[i] = (byte)(2 - GetAt(second, i));
                        first[first.Length - i - 2]--;
                    }
                    else
                        if( GetAt(first, i) > 1)//255
                        {
                            result[i] = 0;
                            first[first.Length - i - 2]--;
                        }
                }               
            }
            Array.Reverse(result);    
            return result;
        }

    } 
}

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
            byte[] binaryArray = { 0, 0, 0, 0, 0, 1, 0, 0 };
            CollectionAssert.AreEqual(binaryArray, ConvertToBaseTwo(4));
        }

        byte[] ConvertToBaseTwo(int decimalNumber)
        {
            byte[] binaryNumber = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int position = 7;
            while(decimalNumber > 0)
            {
                binaryNumber[position] = (byte)(decimalNumber % 2);
                decimalNumber = decimalNumber / 2;
                position--;
            }
            return binaryNumber;
        }
    }
}

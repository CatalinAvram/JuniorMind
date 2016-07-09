using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Călugării dintr-un templul din Benares trebuie să mute 64 de discuri de pe un turn pe altul.
În afară de cele două turnuri mai au la dispoziție un singur alt turn care e suficient de sacru pentru a putea fi folosit.
Cele 64 de discuri au dimensiuni diferite.Iar călugării trebuie să respecte două reguli:
    un singur disc poate fi mutat la un moment dat
    un disc mai mare nu poate fi mutat peste un disc mai mic
Notă: e o problemă clasică de recursivitate, dar care pentru 64 de discuri deja poate cauza probleme de performanță (2^64 - 1 mutări).*/

namespace HanoiTowers
{
    [TestClass]
    public class HanoiTests
    {
        [TestMethod]
        public void MoveOneDisk()
        {
            CollectionAssert.AreEqual(new int[] { 1 }, HanoiTowers(1, new int[] { 1 }, new int[] { 0 }, new int[] { 0 }));
        }

        [TestMethod]
        public void TwoDisks()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2 }, HanoiTowers(2, new int[] { 1, 2 }, new int[2] , new int[2]));
        }

        [TestMethod]
        public void ThreeeDisks()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, HanoiTowers(3, new int[] { 1, 2, 3 }, new int[3], new int[3]));
        }     

        int[] HanoiTowers(int nrOfDisks, int[] source, int[] aux, int[] destination)
        {
            if (nrOfDisks == 1)
                return MoveDisk(1, source, destination);
            else
            {
                HanoiTowers(nrOfDisks - 1, source, destination, aux);
                MoveDisk(nrOfDisks, source, destination);
                HanoiTowers(nrOfDisks - 1, aux, source, destination);
            }
            return destination;
        }  
        
        int[] MoveDisk(int diskNumber, int[] source, int[] destination)
        {
            destination[destination.Length - diskNumber] = source[source.Length - diskNumber];           
            return destination; 
        }                               
    }
}


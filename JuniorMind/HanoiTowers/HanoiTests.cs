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
        public void TwoDisks()
        {
            Assert.AreEqual("S AUX S D AUX D ", HanoiTowers(2, "S", "AUX", "D"));
        }

        [TestMethod]
        public void ThreeDisks()
        {
            Assert.AreEqual("S D S AUX D AUX S D AUX S AUX D S D ", HanoiTowers(3, "S", "AUX", "D"));
        }

        string HanoiTowers(int nrOfDisks, string source, string aux, string destination)
        {
            string moves = "";         
            if (nrOfDisks == 1)
                return MoveDisk(1, source, destination);           
            {
                moves += HanoiTowers(nrOfDisks - 1, source, destination, aux) +
                         MoveDisk(nrOfDisks, source, destination) +
                         HanoiTowers(nrOfDisks - 1, aux, source, destination); 
            }
            return moves;
        }  
        
        string MoveDisk(int diskNumber, string source, string destination)
        {
            return $"{source} {destination} ";
        }                                          
    }
}


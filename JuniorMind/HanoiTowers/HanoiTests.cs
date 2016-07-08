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
            Assert.AreEqual(3, HanoiTowers(2, 'S', 'A', 'D'));
        }

        int HanoiTowers(int nrOfDisks, char source, char aux, char destination)
        {
            if (nrOfDisks == 1)
                return nrOfDisks;
            return HanoiTowers(nrOfDisks - 1, source, destination, aux) +
                    HanoiTowers(1, source, aux, destination) +
                    HanoiTowers(nrOfDisks - 1, aux, source, destination);
        }                                 
    }
}

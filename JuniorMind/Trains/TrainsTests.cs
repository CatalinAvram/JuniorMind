using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Două trenuri pornesc în același timp unul către celălalt cu o viteză constantă de X km/h.
Când cele două trenuri au parcurs o pătrime din distanța inițială, o pasăre aflată pe primul tren pornește în zbor către 
al 2-lea tren cu o viteză de 2X.
Imediat ce a ajuns la el se întoarce către primul și repetă asta până când cele două trenuri se întâlnesc.

Care e distanța zburată de pasăre?*/

namespace Trains
{
    [TestClass]
    public class TrainsTests
    {
        [TestMethod]
        public void FirstTripDistance()
        {
            int distance = FindBirdTripDistance(50, 2);
            Assert.AreEqual(200, distance);
        }
        
        int FindBirdTripDistance(int trainSpeed, int trainsTripTime)
        {
            int birdSpeed = trainSpeed * 2;
            return birdSpeed * trainsTripTime;
        }
    }
}

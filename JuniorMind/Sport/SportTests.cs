using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Un sportiv a efectuat mai multe runde de pregătire.
În prima rundă a efectuat o singură repetiție.
În a doua rundă a efectuat două repetiții și tot așa până la runda N când a ajuns la N repetiții.
După care a început să scadă din nou nr de repetiții, cu câte 1/rundă asta până ce a ajuns din nou la o singură repetiție.

Ajută-l pe sportiv să calculeze câte repetiții a efectuat în total.*/

namespace Sport
{
    [TestClass]
    public class SportTests
    {
        [TestMethod]
        public void numberOfRepetitions()
        {
            int totalRepetions = CalculateNumberOfRepetitions(3);
            Assert.AreEqual(9, totalRepetions);
        }
        int CalculateNumberOfRepetitions(int maximumNumberOfRepetitions)
        {
            return maximumNumberOfRepetitions * maximumNumberOfRepetitions;
        }
    }
}

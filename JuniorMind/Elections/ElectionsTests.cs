using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*La alegeri fiecare secție de votare trimite o listă de candidați și numărul de voturi.
Listele sunt ordonate descrescător în funcție de numărul de voturi.
Crează o funcție care să ajute la centralizarea voturilor.*/
namespace Elections
{
    [TestClass]
    public class ElectionsTests
    {
        [TestMethod]
        public void AlphabeticalSort()
        {
            var candidates = new PollingStation( new Candidate[] { new Candidate("USR", 7), new Candidate("PNL", 3), new Candidate("PSD", 1)  });
            var expectedOrder = new PollingStation(new Candidate[] { new Candidate("PNL", 3), new Candidate("PSD", 1), new Candidate("USR", 7) });
            Assert.AreEqual(expectedOrder, candidates);
        }

        [TestMethod]
        public void SimpleCase()
        {

            var firstPollingStation = new PollingStation(new Candidate[] {  new Candidate("PSD", 1), new Candidate("PNL", 3), new Candidate("USR", 7) });
            var secondPollingStation = new PollingStation(new Candidate[] { new Candidate("PNL", 4), new Candidate("PSD", 4), new Candidate("USR", 6) });
            PollingStation[] sortedStations = new PollingStation[] { firstPollingStation, secondPollingStation };
            Centralizer obj = new Centralizer(sortedStations);

            var expectedOrder = new PollingStation(new Candidate[] { new Candidate("USR", 13), new Candidate("PNL", 7), new Candidate("PSD", 5) });

            Assert.AreEqual(expectedOrder, obj.CentralizePollingStations());
        }

    }
}

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
        public void SortingTest()
        {
            var candidates = new SortedCandidates( new Candidate[] { new Candidate("PNL", 3), new Candidate("PSD", 1), new Candidate("USR", 7) });
            var expectedOrder = new Candidate[] { new Candidate("USR", 7), new Candidate("PNL", 3), new Candidate("PSD", 1) };
            CollectionAssert.AreEqual(expectedOrder, candidates.SortCandidates());
        }
    }
}

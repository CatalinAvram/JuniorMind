using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace IListImplementation
{
    [TestClass]
    public class IListTests
    {
        [TestMethod]
        public void CountTest()
        {
            var integersList = new List<int>();
            Assert.AreEqual(0, integersList.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            var integersList = new List<int>();
            integersList.Add(13);
            integersList.Add(9);
            Assert.AreEqual(2, integersList.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            var integersList = new List<int>();
            integersList.Add(13);
            integersList.Add(9);
            integersList.Clear();
            Assert.AreEqual(0, integersList.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            var integersList = new List<int>() { 9, 13, 9 };
            Assert.AreEqual(true, integersList.Contains(9));
        }
    }
}

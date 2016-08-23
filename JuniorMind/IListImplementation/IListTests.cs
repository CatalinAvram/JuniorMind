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
    }
}

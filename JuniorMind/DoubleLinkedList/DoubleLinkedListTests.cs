using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LinkedList
{
    [TestClass]
    public class DoubleLinkedListTests
    {
        [TestMethod]
        public void AddFirstTest()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 2, 3 } ;
            doublyLinkedList.AddFirst(1);            
            Assert.IsTrue(doublyLinkedList.SequenceEqual(new DoublyLinkedList<int>(){ 1, 2, 3 }));    
        }

        [TestMethod]
        public void AddLastTest()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2 };
            doublyLinkedList.AddLast(3);
            Assert.IsTrue(doublyLinkedList.SequenceEqual(new DoublyLinkedList<int>() { 1, 2, 3 }));
        }

        [TestMethod]
        public void RemoveFirstOccurence()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 3, 2, 4 };
            Assert.IsTrue(doublyLinkedList.Remove(2));
        }

        [TestMethod]
        public void RemoveFirstNode()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 3, 4 };
            doublyLinkedList.RemoveFirst();
            Assert.IsTrue(doublyLinkedList.SequenceEqual(new DoublyLinkedList<int> { 2, 3, 4 }));
        }

        [TestMethod]
        public void RemoveLastNode()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 3, 4 };
            doublyLinkedList.RemoveLast();
            Assert.IsTrue(doublyLinkedList.SequenceEqual(new DoublyLinkedList<int> {1, 2, 3 }));
        }

        [TestMethod]
        public void Clear()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 3, 4 };
            doublyLinkedList.Clear();
            Assert.AreEqual(0, doublyLinkedList.Count);
        }

        [TestMethod]
        public void ContainsGivenElement()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 3, 4 };
            Assert.IsTrue(doublyLinkedList.Contains(4));
        }

        [TestMethod]
        public void FindSpecificNode()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 3, 4 };
            Assert.AreEqual(null, doublyLinkedList.Find(100));

            Node<int> existingNode = doublyLinkedList.Find(3);
            Assert.AreEqual(3, existingNode.Data);
        }

        [TestMethod]
        public void CopyToMethod()
        {
            var doublyLinkedList = new DoublyLinkedList<int> { 1, 2, 7, 9 };
            int[] destinationArray = new int[7];
            int startIndex = 2;
            doublyLinkedList.CopyTo(destinationArray, startIndex);

            CollectionAssert.AreEqual(new int[] {0, 0, 1, 2, 7, 9, 0 }, destinationArray);
        }
    }
}

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
            var doublyLinkedList = new DoublyLinkedList<int>() { 2, 3 } ;
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

    }
}

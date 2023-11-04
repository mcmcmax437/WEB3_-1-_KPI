using NUnit.Framework;
using System;
using Lab1___Ring_collection;

namespace Lab2_CircularLinkedList_Tests
{
    public class CircularLinkedListTests
    {
        [Test]
        public void Add_AddsItemToCircularList()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            list.Add(1);
            list.Add(2);

            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void Delete_RemovesItemFromCircularList()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool result = list.Delete(2);

            Assert.IsTrue(result);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void Delete_RemovesItemFromEmptyList_ThrowsInvalidOperationException()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            Assert.Throws<System.InvalidOperationException>(() => list.Delete(2));
        }

        [Test]
        public void IsCircularList_ChecksIfListIsCircular_ReturnsTrue()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            list.Add(1);
            list.Add(2);

            bool isCircular = list.IsCircularList();

            Assert.IsTrue(isCircular);
        }

        [Test]
        public void IsCircularList_ChecksIfListIsCircular_ReturnsFalse()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            list.Add(1);
            list.Add(2);

            list.Delete(1);


            bool isCircular = list.IsCircularList();

            Assert.IsFalse(isCircular);
        }
    }
}
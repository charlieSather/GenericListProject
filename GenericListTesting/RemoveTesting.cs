using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class RemoveTesting
    {
        [TestMethod]
        public void Remove_RemoveFromEmptyList_ReturnsFalseListDoesNothing()
        {
            GenericList<int> myList = new GenericList<int>();
            Assert.AreEqual(false, myList.Remove(0));
        }

        [TestMethod]
        public void Remove_RemovingItemNotInList_ListRemainsUnchanged()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4 };

            myList.Remove(5);
            myList.Remove(0);

            Assert.AreEqual(1, myList[0]);
        }

        [TestMethod]
        public void Remove_RemoveItem_ReturnsTruesIfItemIsRemoved()
        {
            GenericList<int> myList = new GenericList<int>();
            myList.Add(1);     
            Assert.AreEqual(true, myList.Remove(1));
        }

        [TestMethod]
        public void Remove_CountIsDecremented_CountDecrementedAfterRemove()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };

            myList.Remove(2);
            Assert.AreEqual(2, myList.Count);
        }

        [TestMethod]
        public void Remove_ListShiftsAfterRemove_ListShiftsAndRemainsInOrder()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };

            myList.Remove(2);
            Assert.AreEqual(3, myList[1]);
        }

        [TestMethod]
        public void Remove_ListRemovesOnlyFirstMatch_ListShiftsAndKeepsAnyDuplicatesLeft()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 2 };

            myList.Remove(2);
            Assert.AreEqual(2, myList[2]);
        }

        [TestMethod]
        public void Remove_ListRemovesFromEndOfList_()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };

            myList.Remove(3);
            Assert.AreEqual(2, myList[1]);
        }

    }
}

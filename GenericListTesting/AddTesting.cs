using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class AddTesting
    {
        [TestMethod]
        public void Add_TestAddingItemToEmptyList_ItemAddedToIndexZero()
        {
            GenericList<int> myList = new GenericList<int>();

            int item = 5;
            myList.Add(item);

            Assert.AreEqual(item, myList[0]);
        }
        [TestMethod]
        public void Add_CountIncrementedAfterInsertion_CountIncrementedByOne()
        {
            GenericList<int> myList = new GenericList<int>();

            int item = 5;
            myList.Add(item);

            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void Add_TestAddingItemToNonEmptyList_ItemAddedToEndOfList()
        {
            GenericList<int> myList = new GenericList<int>();

            int itemOne = 5;
            int itemTwo = 10;
            myList.Add(itemOne);
            myList.Add(itemTwo);

            Assert.AreEqual(itemTwo, myList[myList.Count - 1]);
        }

        [TestMethod]
        public void Add_ListRemainsUnchangedAfterAdd_ListHoldsPreviousStateBeforeAdd()
        {
            GenericList<int> myList = new GenericList<int>();

            int itemOne = 5;
            int itemTwo = 10;
            myList.Add(itemOne);
            myList.Add(itemTwo);

            Assert.AreEqual(itemOne, myList[0]);
        }

        [TestMethod]
        public void Add_ListIsFullCapacity_ArrayCapacityIsDoubledAfterAdd()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            Assert.AreEqual(8, myList.Capacity);
        }

        [TestMethod]
        public void Add_ListIsFullCapacity_ListRemainsUnchangedAfterResize()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            Assert.AreEqual(2, myList[1]);
        }


    }
}

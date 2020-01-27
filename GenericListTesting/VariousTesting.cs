using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class VariousTesting
    {
        [TestMethod]
        public void TestListContainsItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(true, myList.Contains(2));
        }

        [TestMethod]
        public void TestListDoesNotContainItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(false, myList.Contains(10));
        }

        [TestMethod]
        public void TestGetIndexAtHasItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(1, myList.GetIndexAt(2));
        }

        [TestMethod]
        public void TestGetIndexAtHasItemAtEnd()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(5, myList.GetIndexAt(6));
        }

        [TestMethod]
        public void TestGetIndexDoesNotHaveItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(-1, myList.GetIndexAt(10));
        }

        [TestMethod]
        public void TestReversList()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.Reverse();

            Assert.AreEqual(5, myList[1]);
        }

        [TestMethod]
        public void TestReversListStringEqual()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.Reverse();

            Assert.AreEqual("654321", myList.ToString());
        }

        [TestMethod]
        public void TestRemoveRangeFourItems()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.RemoveRange(1,4);

            Assert.AreEqual("16", myList.ToString());
        }

        [TestMethod]
        public void TestRemoveRangeAllItems()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.RemoveRange(0,6);

            Assert.AreEqual("", myList.ToString());
        }

        [TestMethod]
        public void TestRemoveRangeExceedsListCount()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.RemoveRange(1,8);

            Assert.AreEqual("1", myList.ToString());
        }

    }
}

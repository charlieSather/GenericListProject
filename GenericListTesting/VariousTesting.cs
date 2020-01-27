using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;
using System.Text;

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

        [TestMethod]
        public void TestGetRangeThreeItems()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            GenericList<int> result = myList.GetRange(1, 3);

            Assert.AreEqual("234", result.ToString());
        }

        [TestMethod]
        public void TestGetRangeCountExceedsListCount()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            GenericList<int> result = myList.GetRange(3, 8);

            Assert.AreEqual("456", result.ToString());
        }


        [TestMethod]
        public void TestGetRangeStartingIndex()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            GenericList<int> result = myList.GetRange(1);

            Assert.AreEqual("23456", result.ToString());
        }


        [TestMethod]
        public void TestCopyTo()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6 };

            int[] result = new int[6];

            myList.CopyTo(result);

            StringBuilder sb = new StringBuilder();
            foreach(int i in result)
            {
                sb.Append(i.ToString());
            }

            Assert.AreEqual("123456", sb.ToString());
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void TestCopyToArraySizeTooSmallToContainTooSmall()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6 };

            int[] result = new int[4];

            myList.CopyTo(result);

            StringBuilder sb = new StringBuilder();
            foreach (int i in result)
            {
                sb.Append(i.ToString());
            }

            Assert.AreEqual("123456", sb.ToString());
        }

        [TestMethod]
        public void TestCopyToArrayIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6 };

            int[] result = new int[9];

            myList.CopyTo(result, 3);

            StringBuilder sb = new StringBuilder();
            foreach (int i in result)
            {
                sb.Append(i.ToString());
            }

            Assert.AreEqual("000123456", sb.ToString());
        }

        [TestMethod]
        public void TestCopyToArrayWithListStartIndexAndArrayStartIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6 };

            int[] result = new int[9];

            myList.CopyTo(0,result, 2 , 4);

            StringBuilder sb = new StringBuilder();
            foreach (int i in result)
            {
                sb.Append(i.ToString());
            }

            Assert.AreEqual("001234000", sb.ToString());
        }





    }
}

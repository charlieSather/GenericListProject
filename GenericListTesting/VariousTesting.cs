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
            myList.RemoveRange(1, 4);

            Assert.AreEqual("16", myList.ToString());
        }

        [TestMethod]
        public void TestRemoveRangeAllItems()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.RemoveRange(0, 6);

            Assert.AreEqual("", myList.ToString());
        }

        [TestMethod]
        public void TestRemoveRangeExceedsListCount()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.RemoveRange(1, 8);

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
            foreach (int i in result)
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

            myList.CopyTo(0, result, 2, 4);

            StringBuilder sb = new StringBuilder();
            foreach (int i in result)
            {
                sb.Append(i.ToString());
            }

            Assert.AreEqual("001234000", sb.ToString());
        }

        [TestMethod]
        public void TestExistsReturnsTrueIfItemMatchesPredicateConditions()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(true, myList.Exists(x => x == "Charlie"));
        }

        [TestMethod]
        public void TestExistsReturnsFalseIfItemDoesNotMatchPredicateConditions()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(false, myList.Exists(x => x == "Chris"));
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestExistsThrowsArgumentNullExcecptionOnNullPredicate()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(false, myList.Exists(null));
        }

        [TestMethod]
        public void TestFindindexOfString()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(3, myList.FindIndex(x => x == "Charlie"));
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestFindindexNullPredicate()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(3, myList.FindIndex(null));
        }

        [TestMethod]
        public void TestFindItemInList()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual("Dave", myList.Find(x => x == "Dave"));
        }

        [TestMethod]
        public void TestFindItemNotInList_DefaultValueIsExpected()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(null, myList.Find(x => x == "Chris"));
        }

        [TestMethod]
        public void TestFindindexCantFindString_ExpectNegativeOne()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(-1, myList.FindIndex(x => x == "Alex"));

        }

        [TestMethod]
        public void TestFindindexFromStartIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6 };

            Assert.AreEqual(3, myList.FindIndex(3, x => x == 4));

        }


        [TestMethod]
        public void TestFindindexFromStartIndexFindsNothing()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6 };

            Assert.AreEqual(-1, myList.FindIndex(3, x => x == 2));

        }

        [TestMethod]
        public void TestFindIndexFromStartIndexAndGivenCount()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(8, myList.FindIndex(3, 6, x => x == 9));
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void TestFindIndexFromStartIndexCountIndexOutOfBounds()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(3, myList.FindIndex(3, 10, x => x == 12));
        }
        
        [TestMethod]
        public void ForEach_TestStringToUpperAction_AllListItemsToUpper()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            StringBuilder sb = new StringBuilder();
            myList.ForEach(x => sb.Append(x.ToUpper()));

            Assert.AreEqual("ADAMSTEVEDAVECHARLIE", sb.ToString());
        }

        [TestMethod]
        public void ForEach_CalculateSumOfAllListItem()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int sum = 0;
            myList.ForEach(delegate (int item)
            {
                sum += item;
            });

            Assert.AreEqual(45, sum);
        }

        [TestMethod]
        public void TestConvertAllIntToString()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            GenericList<string> strList = myList.ConvertAll(new Converter<int, string>(x => x.ToString()));

            Assert.AreEqual(myList[1].ToString(), strList[1]);

        }

        [TestMethod]
        public void TestConvertAllStringToInt()
        {
            GenericList<string> strList = new GenericList<string> { "1","2", "3", "4", "5", "6" };

            GenericList<int> intList = strList.ConvertAll(new Converter<string, int>(x => Int32.Parse(x)));

            Assert.AreEqual(Int32.Parse(strList[1]), intList[1]);

        }

    }
}

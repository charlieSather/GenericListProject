﻿using System;
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
        public void Contains_TestListDoesNotContainItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(false, myList.Contains(10));
        }

        [TestMethod]
        public void IndexOf_ListHasItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(1, myList.IndexOf(2));
        }

        [TestMethod]
        public void IndexOf_ListHasItemAtEnd()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(5, myList.IndexOf(6));
        }

        [TestMethod]
        public void IndexOf_ListDoesNotHaveItem()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(-1, myList.IndexOf(10));
        }
        
        [TestMethod]
        public void IndexOf_ListDoesNotHaveItemFromIndex()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(-1, myList.IndexOf(10,2));
        }

        [TestMethod]
        public void IndexOf_ListHasItemFromIndex()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(4, myList.IndexOf(5, 2));
        }

        [TestMethod]
        public void IndexOf_ListHasItemFromIndexUpToCount()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(4, myList.IndexOf(5, 2, 3));
        }

        [TestMethod]
        public void IndexOf_ListDoesNotHaveItemFromIndexUpToCount()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(-1, myList.IndexOf(10, 2, 3));
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void IndexOf_TestIndexOutOfRange()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });
            myList.IndexOf(2, 10);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void IndexOf_CountExceedsListCount_ExpectIndexOutOfRange()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6 });

            myList.IndexOf(7, 0, 10);
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

        [TestMethod]
        public void FindLast_ListOnlyContainsOneItem_ReturnsItem()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual("Dave", myList.FindLast(x => x == "Dave"));
        }

        [TestMethod]
        public void FindLast_ListDoesNotHaveItemThatMatchesPredicateCriteria_ReturnsItem()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            Assert.AreEqual(null, myList.FindLast(x => x == "Greg"));
        }

        [TestMethod]
        public void FindLast_ListHasMultipleItemsThatMeetMatchPredicate_ReturnsLastMatch()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie","Steve", "Carl" };

            Assert.AreEqual("Steve", myList.FindLast(x => x == "Steve"));
        }

        [TestMethod]
        public void FindLastIndex_ListHasMatchingItem_ReturnsIndexOfLastMatch()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            Assert.AreEqual(2, myList.FindLastIndex(x => x == "Dave"));
        }
        [TestMethod]
        public void FindLastIndex_ListDoesNotHaveItem_ReturnNegativeOne()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            Assert.AreEqual(-1, myList.FindLastIndex(x => x == "Jeff"));
        }

        [TestMethod]
        public void FindLastIndex_ListHasMultipleItemsFromIndex_ReturnsIndexOfLastMatch()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            Assert.AreEqual(4, myList.FindLastIndex(1, x => x == "Steve"));
        }

        [TestMethod]
        public void FindLastIndex_ListDoesNotHaveItemWithMathingCriteria_ReturnsNegativeOne()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            Assert.AreEqual(-1, myList.FindLastIndex(4, x => x == "Adam"));
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void FindLastIndex_StartIndexOutOfRange()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.FindLastIndex(10, x => x == "Steve");
        }

        [TestMethod]
        public void FindLastIndex_ListHasMultipleItemsFromIndexUpToCoount_ReturnsIndexOfLastMatch()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl", "Jeff" };

            Assert.AreEqual(4, myList.FindLastIndex(1, 6, x => x == "Steve"));
        }

        [TestMethod]
        public void FindLastIndex_ListDoesNotHaveItemWithMathingCriteriaUpToCount_ReturnsNegativeOne()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            Assert.AreEqual(-1, myList.FindLastIndex(2, 4, x => x == "Adam"));
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void FindLastIndex_CountExceedsListCount_ThrowException()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.FindLastIndex(0,10, x => x == "Greg");
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void Insert_IndexOutOfRange_ThrowException()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.Insert(-1,"Jeff");
        }

        [TestMethod]
        public void Insert_TestInsertAtBeginning()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.Insert(0, "Jeff");
            Assert.AreEqual("Jeff", myList[0]);
        }

        [TestMethod]
        public void Insert_InsertIntoEmptyList()
        {
            GenericList<string> myList = new GenericList<string>();

            myList.Insert(0, "Jeff");
            Assert.AreEqual("Jeff", myList[0]);
        }

        [TestMethod]
        public void Insert_IndexEqualsListCount()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.Insert(6, "Jeff");
            Assert.AreEqual("Jeff", myList[6]);
        }

        [TestMethod]
        public void Insert_CountUpdatedAfterSuccessfulInsert()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.Insert(4, "Jeff");
            Assert.AreEqual(7, myList.Count);
        }

        [TestMethod]
        public void Insert_CapacityIsEqualToList()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            myList.Insert(2, "Jeff");
            Assert.AreEqual(8, myList.Capacity);
        }

        [TestMethod]
        public void Insert_InsertItemIntoNonEmptyList()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.Insert(3, "Jeff");
            Assert.AreEqual("Jeff", myList[3]);
        }

        [TestMethod]
        public void Insert_AfterSuccessfuInsert_ListShiftsRight()
        {
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie", "Steve", "Carl" };

            myList.Insert(2,"Jeff");
            Assert.AreEqual("AdamSteveJeffDaveCharlieSteveCarl", myList.ToString());
        }

    }
}

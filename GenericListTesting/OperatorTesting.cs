using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class OperatorTesting
    {
        [TestMethod]
        public void Plus_ConcatenateListCheckSecondList()
        {
            GenericList<int> myList = new GenericList<int>();
            GenericList<int> myListTwo = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            myListTwo.Add(4);
            myListTwo.Add(5);
            myListTwo.Add(6);

            GenericList<int> concatList = new GenericList<int>();
            concatList = myList + myListTwo;

            Assert.AreEqual(4, concatList[3]);

        }

        [TestMethod]
        public void Plus_ConcatenateListCheckFirstList()
        {
            GenericList<int> myList = new GenericList<int>();
            GenericList<int> myListTwo = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            myListTwo.Add(4);
            myListTwo.Add(5);
            myListTwo.Add(6);

            GenericList<int> concatList = new GenericList<int>();
            concatList = myList + myListTwo;

            Assert.AreEqual(2, concatList[1]);
        }
        [TestMethod]
        public void Plus_ConcatenateListAreEqual()
        {
            GenericList<int> listOne = new GenericList<int> { 1, 2, 3 };
            GenericList<int> listTwo = new GenericList<int> { 4, 5, 6 };

            GenericList<int> result = listOne + listTwo;
            Assert.AreEqual("123456", result.ToString());

        }

        [TestMethod]
        public void PlusOperator_ConcatenateListCountProperlyUpdated()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int> { 4, 5, 6 };
         
            GenericList<int> concatList = new GenericList<int>();
            concatList = myList + myListTwo;

            Assert.AreEqual(6, concatList.Count);
        }
        [TestMethod]
        public void PlusOperator_ConcatenateListAddsNothingIfSecondListEmpty()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int>();

            GenericList<int> concatList = new GenericList<int>();
            concatList = myList + myListTwo;

            Assert.AreEqual(3, concatList.Count);
        }
        [TestMethod]
        public void PlusOperator_ConcatenateListRemainsUnchangedIfSecondListEmpty()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int>();

            GenericList<int> concatList = new GenericList<int>();
            concatList = myList + myListTwo;

            Assert.AreEqual(3, concatList[2]);
        }


        [TestMethod]
        public void RemoveOperator_RemovesIfItemsEqual()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int> { 1, 3, 5 };

            GenericList<int> result = new GenericList<int>();
            result = myList - myListTwo;

            Assert.AreEqual(2, result[0]);
        }
        [TestMethod]
        public void RemoveOperator_LeavesFirstListUnmodified()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int> { 1, 3, 5 };

            GenericList<int> result = myList - myListTwo;

            Assert.AreEqual("123", myList.ToString());
        }



        [TestMethod]
        public void RemoveOperator_RemovesDuplicates()
        {
            GenericList<int> myList = new GenericList<int> { 2, 2, 2, 2, 1 };
            GenericList<int> myListTwo = new GenericList<int> { 2, 3, 5 };

            GenericList<int> result = new GenericList<int>();
            result = myList - myListTwo;

            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void RemoveOperator_RemovesNothingIfItemsNotEqual()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int> { 4, 5, 6 };

            GenericList<int> result = new GenericList<int>();
            result = myList - myListTwo;

            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void Indexer_RemoveOperator_UpdatesCountProperly()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            GenericList<int> myListTwo = new GenericList<int> { 4, 2, 3 };

            GenericList<int> result = new GenericList<int>();
            result = myList - myListTwo;

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetIndexOutOfRangeExceptionPositiveIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            Console.WriteLine(myList[10]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_GetIndexOutOfRangeExceptionNegativeIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            Console.WriteLine(myList[-10]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_SetIndexOutOfRangeExceptionPositiveIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            myList[10] = 20;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_SetIndexOutOfRangeExceptionNegativeIndex()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            myList[-10] = 20;
        }
    }
}

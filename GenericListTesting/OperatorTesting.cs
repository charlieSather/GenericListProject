﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class OperatorTesting
    {
        [TestMethod]
        public void ConcatenateListCheckSecondList()
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
        public void ConcatenateListCheckFirstList()
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
        public void ConcatenateListCountProperlyUpdated()
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

            Assert.AreEqual(6, concatList.Count);
        }
        [TestMethod]
        public void ConcatenateListAddsNothingIfSecondListEmpty()
        {
            GenericList<int> myList = new GenericList<int>();
            GenericList<int> myListTwo = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            GenericList<int> concatList = new GenericList<int>();

            concatList = myList + myListTwo;

            Assert.AreEqual(3, concatList.Count);
        }
        [TestMethod]
        public void ConcatenateListRemainsUnchangedIfSecondListEmpty()
        {
            GenericList<int> myList = new GenericList<int>();
            GenericList<int> myListTwo = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            GenericList<int> concatList = new GenericList<int>();

            concatList = myList + myListTwo;

            Assert.AreEqual(3, concatList[2]);
        }


        [TestMethod]
        public void RemoveOperatorRemovesIfItemsEqual()
        {
            GenericList<int> myList = new GenericList<int>();
            GenericList<int> myListTwo = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            myListTwo.Add(1);
            myListTwo.Add(3);
            myListTwo.Add(5);

            GenericList<int> result = new GenericList<int>();

            result = myList - myListTwo;

            Assert.AreEqual(2, result[0]);
        }
        [TestMethod]
        public void RemoveOperatorRemovesNothingIfItemsNotEqual()
        {
            GenericList<int> myList = new GenericList<int>();
            GenericList<int> myListTwo = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            myListTwo.Add(4);
            myListTwo.Add(5);
            myListTwo.Add(6);

            GenericList<int> result = new GenericList<int>();

            result = myList - myListTwo;

            Assert.AreEqual(1, result[0]);
        }
    }
}
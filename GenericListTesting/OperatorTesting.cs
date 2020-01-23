using System;
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
    }
}

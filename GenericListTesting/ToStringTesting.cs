using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class ToStringTesting
    {
        [TestMethod]
        public void ToString_TestIntList()
        {
            GenericList<int> myList = new GenericList<int>() { 1, 2, 3 };
            Assert.AreEqual("123", myList.ToString());
        }

        [TestMethod]
        public void ToString_TestStringList()
        {
            GenericList<string> myList = new GenericList<string> { "Hello", "World" };
            Assert.AreEqual("HelloWorld", myList.ToString());
        }

        [TestMethod]
        public void ToString_OrderIsPreserved()
        {
            GenericList<int> myList = new GenericList<int> { 1, 2, 3 };
            string actual = myList.ToString();

            Assert.AreEqual('2', actual[1]);
        }
        
        [TestMethod]
        public void ToString_TestEmptyListReturnsEmptyString()
        {
            GenericList<int> myList = new GenericList<int>();

            Assert.AreEqual("", myList.ToString());
        }



    }
}

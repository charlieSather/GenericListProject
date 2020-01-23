using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class ToStringTesting
    {
        [TestMethod]
        public void TestIntList()
        {
            GenericList<int> myList = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            Assert.AreEqual("123", myList.ToString());
        }

        [TestMethod]
        public void TestStringList()
        {
            GenericList<string> myList = new GenericList<string>();

            myList.Add("Hello");
            myList.Add("World");

            Assert.AreEqual("HelloWorld", myList.ToString());
        }

        
    }
}

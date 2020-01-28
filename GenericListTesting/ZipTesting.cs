using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class ZipTesting
    {
        [TestMethod]
        public void Zip_SameSizeList()
        {
            GenericList<int> odd = new GenericList<int> { 1, 3, 5 };
            GenericList<int> even = new GenericList<int> { 2, 4, 6 };

            GenericList<int> result = odd.Zip(even);
            Assert.AreEqual(2, result[1]);
        }

        [TestMethod]
        public void Zip_SmallerList()
        {
            GenericList<int> odd = new GenericList<int> { 1, 3, 5 };
            GenericList<int> even = new GenericList<int> { 2 };

            GenericList<int> result = odd.Zip(even);
            Assert.AreEqual(2, result[1]);
        }

        [TestMethod]
        public void Zip_LargerList()
        {
            GenericList<int> odd = new GenericList<int>() { 1, 3 };
            GenericList<int> even = new GenericList<int> { 2, 4, 6 };

            GenericList<int> result = odd.Zip(even);
            Assert.AreEqual(4, result[3]);
        }

        [TestMethod]
        public void Zip_UpdatesCountCorrectly()
        {
            GenericList<int> odd = new GenericList<int>() { 1 };
            GenericList<int> even = new GenericList<int> { 2, 4, 6 };

            GenericList<int> result = odd.Zip(even);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void Zip_EmptyList()
        {
            GenericList<int> odd = new GenericList<int>() { 1, 3, 5 };
            GenericList<int> even = new GenericList<int>();

            GenericList<int> result = odd.Zip(even);
            Assert.AreEqual(odd.Count, result.Count);
        }
    }
}

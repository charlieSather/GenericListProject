using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;

namespace GenericListTesting
{
    [TestClass]
    public class ZipTesting
    {
        [TestMethod]
        public void ZipSameSizeList()
        {
            GenericList<int> odd = new GenericList<int>();
            GenericList<int> even = new GenericList<int>();

            odd.Add(1);
            odd.Add(3);
            odd.Add(5);

            even.Add(2);
            even.Add(4);
            even.Add(6);

            GenericList<int> result = odd.Zip(even);

            Assert.AreEqual(2, result[1]);
        }

        [TestMethod]
        public void ZipSmallerList()
        {
            GenericList<int> odd = new GenericList<int>();
            GenericList<int> even = new GenericList<int>();

            odd.Add(1);
            odd.Add(3);
            odd.Add(5);

            even.Add(2);

            GenericList<int> result = odd.Zip(even);

            Assert.AreEqual(3, result[2]);
        }

        [TestMethod]
        public void ZipLargerList()
        {
            GenericList<int> odd = new GenericList<int>();
            GenericList<int> even = new GenericList<int>();

            odd.Add(1);

            even.Add(2);
            even.Add(4);
            even.Add(6);

            GenericList<int> result = odd.Zip(even);

            Assert.AreEqual(4, result[2]);
        }

        [TestMethod]
        public void ZipUpdatesCountCorrectly()
        {
            GenericList<int> odd = new GenericList<int>();
            GenericList<int> even = new GenericList<int>();

            odd.Add(1);

            even.Add(2);
            even.Add(4);
            even.Add(6);

            GenericList<int> result = odd.Zip(even);

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void ZipEmptyList()
        {
            GenericList<int> odd = new GenericList<int>();
            GenericList<int> even = new GenericList<int>();

            odd.Add(1);
            odd.Add(3);
            odd.Add(5);          

            GenericList<int> result = odd.Zip(even);

            Assert.AreEqual(odd.Count, result.Count);
        }
    }
}

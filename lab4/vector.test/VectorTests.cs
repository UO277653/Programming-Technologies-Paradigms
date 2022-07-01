using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace vector.test
{
    [TestClass]
    public class VectorTests
    {
        [ClassInitialize]
        public static void InitializeAllTheTests(TestContext testContext)
        {
        }

        [TestInitialize]
        public void InitializeTests()
        {

        }

        [TestCleanup]
        public void CleanUpTests()
        {
        }

        [ClassCleanup]
        public static void CleanUpAllTheTests()
        {
        }

        [TestMethod]
        public void TestAdd()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            Assert.IsTrue(list.Contains("a"));
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestNumberOfElements()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            Assert.AreEqual(1, list.Count);
            list.Add("b");
            Assert.AreEqual(2, list.Count);
            list.Remove("b");
            Assert.AreEqual(1, list.Count);
            list.Remove("a");
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestGetAndSet()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            Assert.AreEqual("a", list[0]);
            Assert.AreEqual(1, list.Count);
            list[0] = "b";
            Assert.AreEqual("b", list[0]);
        }

        [TestMethod]
        public void TestContains()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            Assert.IsTrue(list.Contains("a"));
            Assert.IsFalse(list.Contains("b"));
            list.Remove("a");
            Assert.IsFalse(list.Contains("a"));
        }

        [TestMethod]
        public void TestGetFirstIndex()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            list.Add("b");
            list.Add("a");
            Assert.AreEqual(0, list.IndexOf("a"));
            Assert.AreEqual(1, list.IndexOf("b"));
        }

        [TestMethod]
        public void TestDeleteFirstOccurrence()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            list.Add("b");
            list.Add("a");
            list.Remove("a");
            Assert.IsTrue(list.Contains("a"));
            Assert.AreEqual(1, list.IndexOf("a"));
        }

        [TestMethod]
        public void TestIterateForEach()
        {
            IList<String> list = new List<String>();
            list.Add("a");
            list.Add("b");
            list.Add("c");

            foreach(String s in list){
                Console.WriteLine(s.ToString());
            }
        }
    }
}

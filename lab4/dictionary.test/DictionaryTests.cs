using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace dictionary.test
{
    [TestClass]
    public class DictionaryTests
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
            IDictionary<String, String> list = new Dictionary<String, String>();
            list.Add("1","a");
            Assert.IsTrue(list.ContainsKey("1"));
            Assert.AreEqual(1, list.Count);
            list.Add("2", "a");
            Assert.IsTrue(list.ContainsKey("2"));
        }

        [TestMethod]
        public void TestNumberOfPairs()
        {
            IDictionary<String, String> list = new Dictionary<String, String>();
            list.Add("1", "a");
            Assert.AreEqual(1, list.Count);
            list.Add("2", "a");
            Assert.AreEqual(2, list.Count);
            list.Remove("1");
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestGetAndSet()
        {
            IDictionary<String, String> list = new Dictionary<String, String>();
            list.Add("1", "a");
            list.Add("2", "b");
            Assert.AreEqual("a", list["1"]);
            list["1"] = "c";
            Assert.AreEqual("c", list["1"]);
        }

        [TestMethod]
        public void TestKeyExists()
        {
            IDictionary<String, String> list = new Dictionary<String, String>();
            list.Add("1", "a");
            list.Add("2", "b");
            Assert.IsTrue(list.ContainsKey("1"));
            Assert.IsTrue(list.ContainsKey("2"));
            Assert.IsFalse(list.ContainsKey("3"));
        }

        [TestMethod]
        public void TestDeleteKey()
        {
            IDictionary<String, String> list = new Dictionary<String, String>();
            list.Add("1", "a");
            list.Remove("1");
            Assert.IsFalse(list.ContainsKey("1"));
        }

        [TestMethod]
        public void TestForEach()
        {
            IDictionary<String, String> list = new Dictionary<String, String>();
            list.Add("1", "a");
            list.Add("2", "b");
            list.Add("3", "c");
            foreach (var value in list) {
                Console.WriteLine(value.ToString());
            }
        }
    }
}

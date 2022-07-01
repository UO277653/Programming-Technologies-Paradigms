using generic.linked.list;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPP.Laboratory.ObjectOrientation.Lab02;

namespace test.generic.linked.list
{
    [TestClass]
    public class LinkedListTest
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
        public void TestListWithString()
        {
            LinkedList<String> res = new LinkedList<String>();

            res.Add("a");
            Assert.AreEqual(1, res.NumberOfElements);

            Assert.AreEqual("a", res.GetElement(0));

            res.Remove(0);
            Assert.AreEqual(0, res.NumberOfElements);

            res.Add("a");
            res.Add("b");
            res.Remove(0);
            Assert.IsFalse(res.Contains("a"));
            Assert.IsTrue(res.Contains("b"));

            Assert.AreEqual("b", res.GetElement(0));
            Assert.AreEqual("b \n", res.ToString());
        }

        [TestMethod]
        public void TestListWithPerson()
        {
            LinkedList<Person> res = new LinkedList<Person>();

            Person p1 = new Person("Adrian", "Stanci", "ABC");
            res.Add(p1);
            Assert.AreEqual(1, res.NumberOfElements);

            Assert.AreEqual(p1, res.GetElement(0));

            res.Remove(0);
            Assert.AreEqual(0, res.NumberOfElements);

            Person p2 = new Person("Stelian", "Stanci", "BCD");
            res.Add(p1);
            res.Add(p2);
            res.Remove(0);
            Assert.IsFalse(res.Contains(p1));
            Assert.IsTrue(res.Contains(p2));

            Assert.AreEqual(p2, res.GetElement(0));
        }

        [TestMethod]
        public void TestListWithIntegers()
        {
            LinkedList<int> res = new LinkedList<int>(); 

            res.Add(1);
            Assert.AreEqual(1, res.NumberOfElements);

            Assert.AreEqual(1, res.GetElement(0));

            res.Remove(0);
            Assert.AreEqual(0, res.NumberOfElements);

            res.Add(1);
            res.Add(2);
            res.Remove(0);
            Assert.IsFalse(res.Contains(1));
            Assert.IsTrue(res.Contains(2));

            Assert.AreEqual(2, res.GetElement(0));
            Assert.AreEqual("2 \n", res.ToString());
        }

        [TestMethod]
        public void TestListWithDoubles()
        {
            LinkedList<double> res = new LinkedList<double>();

            res.Add(1.0);
            Assert.AreEqual(1, res.NumberOfElements);

            Assert.AreEqual(1.0, res.GetElement(0));

            res.Remove(0);
            Assert.AreEqual(0, res.NumberOfElements);

            res.Add(1.0);
            res.Add(2.0);
            res.Remove(0);
            Assert.IsFalse(res.Contains(1.0));
            Assert.IsTrue(res.Contains(2.0));

            Assert.AreEqual(2.0, res.GetElement(0));
            Assert.AreEqual("2 \n", res.ToString());
        }
    }
}

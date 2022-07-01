using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace test.stack
{
    [TestClass]
    public class TestStack
    {
        private Stack<string> stack;

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
        public void TestStackWithString()
        {
            Stack<string> s = new Stack<string>(2);

            Assert.IsTrue(s.IsEmpty);

            s.Push("a");

            Assert.IsTrue(!s.IsEmpty);
            Assert.IsTrue(!s.IsFull);

            s.Push("b");

            Assert.IsTrue(s.IsFull);

            s.Push("c"); // Nothing should happen

            Assert.IsTrue(s.IsFull);

            Assert.AreEqual("b", s.Pop());

            Assert.IsTrue(!s.IsFull);

            Assert.AreEqual("a", s.Pop());

            Assert.IsTrue(s.IsEmpty);

            Assert.AreEqual(null, s.Pop());
        }

        [TestMethod]
        public void TestStackWithIntegers()
        {
            Stack<int> s = new Stack<int>(2);

            Assert.IsTrue(s.IsEmpty);

            s.Push(1);

            Assert.IsTrue(!s.IsEmpty);
            Assert.IsTrue(!s.IsFull);

            s.Push(2);

            Assert.IsTrue(s.IsFull);

            s.Push(3); // Nothing should happen

            Assert.IsTrue(s.IsFull);

            Assert.AreEqual(2, s.Pop());

            Assert.IsTrue(!s.IsFull);

            Assert.AreEqual(1, s.Pop());

            Assert.IsTrue(s.IsEmpty);

            Assert.AreEqual(0, s.Pop());
        }

        [TestMethod]
        public void TestStackWithPerson()
        {
            Stack<Person> s = new Stack<Person>(2);

            Person p1 = new Person("Adrian", "Stanci", "a");
            Person p2 = new Person("Stanci", "Adrian", "a");
            Person p3 = new Person("Stelian", "Stanci", "a");

            Assert.IsTrue(s.IsEmpty);

            s.Push(p1);

            Assert.IsTrue(!s.IsEmpty);
            Assert.IsTrue(!s.IsFull);

            s.Push(p2);

            Assert.IsTrue(s.IsFull);

            s.Push(p3); // Nothing should happen

            Assert.IsTrue(s.IsFull);

            Assert.AreEqual(p2, s.Pop());

            Assert.IsTrue(!s.IsFull);

            Assert.AreEqual(p1, s.Pop());

            Assert.IsTrue(s.IsEmpty);

            Assert.AreEqual(null, s.Pop());
        }
    }
}

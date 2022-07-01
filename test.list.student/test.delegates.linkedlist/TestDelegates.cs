using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.Functional.Lab05;
using linkedlist;
using System.Linq;

namespace test.delegates
{
    [TestClass]
    public class TestDelegates
    {
        static LinkedList<Person> people;
        static LinkedList<Angle> angles;

        [ClassInitialize]
        public static void InitializeAllTheTests(TestContext testContext)
        {
            people = new LinkedList<Person>();
            Person[] factoryPeople = Factory.CreatePeople();
            for (int i = 0; i < factoryPeople.Length; i++)
            {
                people.Add(factoryPeople[i]);
            }

            angles = new LinkedList<Angle>();
            Angle[] factoryAngles = Factory.CreateAngles();
            for (int i = 0; i < factoryAngles.Length; i++)
            {
                angles.Add(factoryAngles[i]);
            }
        }

        [TestMethod]
        public void TestFindByNameAndID()
        {
            Console.WriteLine(people.Find((p) => p.FirstName.EndsWith("n") || p.IDNumber.EndsWith("s")));
        }

        [TestMethod]
        public void TestFindRightAngle()
        {
            Console.WriteLine(angles.Find((p) => p.Degrees == 90));
        }

        [TestMethod]
        public void TestFindByQuadrant()
        {
            Console.WriteLine(angles.Find((p) => p.Quadrant == 1).Degrees);
            Console.WriteLine(angles.Find((p) => p.Quadrant == 2).Degrees);
            Console.WriteLine(angles.Find((p) => p.Quadrant == 3).Degrees);
            Console.WriteLine(angles.Find((p) => p.Quadrant == 4).Degrees);
        }

        [TestMethod]
        public void TestFilterByNameAndID()
        {
            Console.WriteLine(people.Filter((p) => p.FirstName.EndsWith("n") || p.IDNumber.EndsWith("s")));
        }

        [TestMethod]
        public void TestFilterRightAngle()
        {
            Console.WriteLine(angles.Filter((p) => p.Degrees == 90));
        }

        [TestMethod]
        public void TestFilterByQuadrant()
        {
            Console.WriteLine(angles.Filter((p) => p.Quadrant == 1).ToString());
            Console.WriteLine(angles.Filter((p) => p.Quadrant == 2).ToString());
            Console.WriteLine(angles.Filter((p) => p.Quadrant == 3).ToString());
            Console.WriteLine(angles.Filter((p) => p.Quadrant == 4).ToString());
        }

        [TestMethod]
        public void TestReduceSumAngles()
        {
            Assert.AreEqual(64980, angles.Reduce<double>((a, p) => a + p.Degrees));
        }

        [TestMethod]
        public void TestReduceMaximumSine()
        {
            Assert.AreEqual(1, angles.Reduce<double>((a, p) => p.Sine() > a ? p.Sine() : a));
        }

        [TestMethod]
        public void TestReduceCountNames()
        {
            Assert.AreEqual(2, people.Reduce<double>((n, p) => n + (p.FirstName.Equals("María") ? 1 : 0)));
            Assert.AreEqual(2, people.Reduce<double>((n, p) => n + (p.FirstName.Equals("Juan") ? 1 : 0)));
        }

        // Tests of map
        [TestMethod]
        public void TestMapSurnameName()
        {
            Func<Person, String> lambda = (Person p) => p.FirstName + " " + p.Surname;
            var res = people.Map<String>(lambda);

            foreach(var element in res)
            {
                Console.WriteLine(element.ToString());
            }
        }

        [TestMethod]
        public void TestMapAngleQuadrants()
        {
            Func<Angle, int> lambda = (Angle a) => a.Quadrant;
            var res = angles.Map<int>(lambda);

            foreach (var element in res)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}

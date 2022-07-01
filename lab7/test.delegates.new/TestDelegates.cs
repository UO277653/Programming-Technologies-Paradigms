using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using linkedlist;
using System.Linq;
using delegates;
using TPP.Laboratory.Functional.Lab05;

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
            Console.WriteLine(Program.Find<Person>(people, (p) => p.FirstName.EndsWith("n") || p.IDNumber.EndsWith("s")));
        }

        [TestMethod]
        public void TestFindRightAngle()
        {
            Console.WriteLine(Program.Find<Angle>(angles, (p) => p.Degrees == 90));
        }

        [TestMethod]
        public void TestFindByQuadrant()
        {
            Console.WriteLine(Program.Find<Angle>(angles, (p) => p.Quadrant == 1).Degrees);
            Console.WriteLine(Program.Find<Angle>(angles, (p) => p.Quadrant == 2).Degrees);
            Console.WriteLine(Program.Find<Angle>(angles, (p) => p.Quadrant == 3).Degrees);
            Console.WriteLine(Program.Find<Angle>(angles, (p) => p.Quadrant == 4).Degrees);
        }

        [TestMethod]
        public void TestFilterByNameAndID()
        {
            Console.WriteLine(Program.Filter<Person>(people, (p) => p.FirstName.EndsWith("n") || p.IDNumber.EndsWith("s")));
        }

        [TestMethod]
        public void TestFilterRightAngle()
        {
            Console.WriteLine(Program.Filter<Angle>(angles, (p) => p.Degrees == 90));
        }

        [TestMethod]
        public void TestFilterByQuadrant()
        {
            Console.WriteLine(Program.Filter<Angle>(angles, (p) => p.Quadrant == 1).ToString());
            Console.WriteLine(Program.Filter<Angle>(angles, (p) => p.Quadrant == 2).ToString());
            Console.WriteLine(Program.Filter<Angle>(angles, (p) => p.Quadrant == 3).ToString());
            Console.WriteLine(Program.Filter<Angle>(angles, (p) => p.Quadrant == 4).ToString());
        }

        [TestMethod]
        public void TestReduceSumAngles()
        {
            Assert.AreEqual(64980, Program.Reduce<double, Angle>(angles, (a, p) => a + p.Degrees));
        }

        [TestMethod]
        public void TestReduceMaximumSine()
        {
            Assert.AreEqual(1, Program.Reduce<double, Angle>(angles, (a, p) => p.Sine() > a ? p.Sine() : a));
        }

        [TestMethod]
        public void TestReduceCountNames()
        {
            Assert.AreEqual(2, Program.Reduce<double, Person>(people, (n, p) => n + 1, (p) => p.FirstName.Equals("María")));
            Assert.AreEqual(2, Program.Reduce<double, Person>(people, (n, p) => n + 1, (p) => p.FirstName.Equals("Juan")));
        }

        // Tests of map
        [TestMethod]
        public void TestMapSurnameName()
        {
            Func<Person, String> lambda = (Person p) => p.FirstName + " " + p.Surname;
            var res = Program.Map<Person, String>(lambda, people);

            foreach(var element in res)
            {
                Console.WriteLine(element.ToString());
            }
        }

        [TestMethod]
        public void TestMapAngleQuadrants()
        {
            Func<Angle, int> lambda = (Angle a) => a.Quadrant;
            var res = Program.Map<Angle, int>(lambda, angles);

            foreach (var element in res)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}

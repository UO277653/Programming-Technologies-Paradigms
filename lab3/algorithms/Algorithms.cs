
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    static class ExtensionMethods
    {
        public static int IndexOf(this object[] array, object o, IComparator predicate = null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.EqualsMethod(o, array[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }

    interface IComparator
    {
        public bool EqualsMethod(object obj1, object obj2);
    }

    class ComparePersonByName : IComparator
    {
        public bool EqualsMethod(object obj1, object obj2)
        {
            Person p1 = obj1 as Person;
            Person p2 = obj2 as Person;
            if (p1 != null && p2 != null)
            {
                if (p1.FirstName.Equals(p2.FirstName))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class CompareAnglesByQuadrant : IComparator
    {
        public bool EqualsMethod(object obj1, object obj2)
        {
            Angle a1 = obj1 as Angle;
            Angle a2 = obj2 as Angle;
            if (a1 != null && a2 != null)
            {
                if((a1.Degrees > 0 && a1.Degrees <= 90) && (a2.Degrees > 0 && a2.Degrees <= 90)) 
                {
                    return true;
                }
                if ((a1.Degrees > 90 && a1.Degrees <= 180) && (a2.Degrees > 90 && a2.Degrees <= 180))
                {
                    return true;
                }
                if ((a1.Degrees > 180 && a1.Degrees <= 270) && (a2.Degrees > 180 && a2.Degrees <= 270))
                {
                    return true;
                }
                if ((a1.Degrees > 270 && a1.Degrees <= 360) && (a2.Degrees > 0 && a2.Degrees <= 360))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Algorithms {

        // Exercise: Implement an IndexOf method that finds the first position (index) 
        // of an object in an array of objects. It should be valid for Person, Angle and future classes.

        static Person[] CreatePeople() {
            string[] firstnames = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
            int numberOfPeople = 100;

            Person[] printOut = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printOut[i] = new Person(
                    firstnames[random.Next(0, firstnames.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return printOut;
        }

        static Angle[] CreateAngles() {
            Angle[] angles = new Angle[(int)(Math.PI * 2 * 10)];
            int i = 0;
            while (i < angles.Length) {
                angles[i] = new Angle(i / 10.0);
                i++;
            }
            return angles;
        }

        static void Main() {
            // To be done by the student
            Person[] people = CreatePeople();
            Person p = new Person("Adrian", "Stanci", "1");
            people[0] = p;

            //int index = IndexOf((object) p, (object[]) people);
            //Console.WriteLine(index);
            people.IndexOf(people[10], new ComparePersonByName());

            Angle[] angles = CreateAngles();
            int res = angles.IndexOf(angles[1], new CompareAnglesByQuadrant());
            Console.WriteLine(res);
        }

    }

}

using System;
using System.Collections.Generic;
using linkedlist;

namespace lab4
{

    public class Person
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 0;
            Swap(ref a, ref  b);
            Console.WriteLine(a); // 0
            Console.WriteLine(b); // 10

            string s1 = "a";
            string s2 = "b";
            Swap(ref s1, ref s2);
            Console.WriteLine(s1); // b
            Console.WriteLine(s2); // a

            Console.WriteLine(Maximum(s1, s2).ToString());

            linkedlist.LinkedList<String> list = new linkedlist.LinkedList<String>();

            list.Add(s1);
            list.Add(s2);

            Console.WriteLine("Writing the contents of the list");

            foreach (String s in list)
            {
                Console.WriteLine(s.ToString());
            }

            // Syntactic sugar for
            //var myEnumerator = list.GetEnumerator();

            //while(myEnumerator.MoveNext()) // True when has next
            //{
            //    String s = myEnumerator.Current;
            //    Console.WriteLine(s);
            //}
        }

        public static void Swap<T>(ref T obj1, ref  T obj2)
        {
            T aux = obj1;

            obj1 = obj2;

            obj2 = aux;
        }

        public static T Maximum<T>(T obj1, T obj2) where T: IComparable<T>
        {
            if(obj1.CompareTo(obj2) > 0)
            {
                return obj1;
            }
            return obj2;
        }


    }
}

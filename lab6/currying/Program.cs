using System;

namespace TPP.Laboratory.Functional.Lab06 {

    class Program {

        static int Addition(int a, int b) {
            return a + b;
        }

        static Func<int, int> CurryedAdd(int a)
        {
            return b => b + a;
        }

        static Predicate<int> DivisorOf(int a)
        {
            return b => b % a == 0;
        }

        static void Main() {
            Console.WriteLine(Addition(1, 2));

            Func<int, int> increment = CurryedAdd(1);

            int[] integers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach(var i in integers) // Imperative
            {
                Console.WriteLine(increment(i));
            }

            //integers.Map(increment).Show(); // More declarative

            integers.Filter(DivisorOf(2)).Show();
        }
    }
}

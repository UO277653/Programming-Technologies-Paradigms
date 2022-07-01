using System;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Try to guess the behavior of this program without running it
    /// </summary>
    class Closures {

        /// <summary>
        /// Version with a single method
        /// </summary>
        //static Func<int> Counter() {
        //    int counter = 0;
        //    return () => ++counter;
        //}

        // Constructor setting counter value
        static void Counter(int initialValue, out Func<int> increment, out Func<int> decrement, out Action<int> assign)
        {
            int counter = initialValue;
            increment = () => ++counter;
            decrement = () => --counter;
            assign = (int newValue) => counter = newValue;
        }

        static void Main() {
            //Func<int> counter = Counter();
            //Console.WriteLine(counter());
            //Console.WriteLine(counter());
            
            //Func<int> anotherCounter = Counter();
            //Console.WriteLine(anotherCounter());
            //Console.WriteLine(anotherCounter());

            //Console.WriteLine(counter());
            //Console.WriteLine(counter());

            Func<int> i;
            Func<int> d;
            Action<int> a;

            Counter(9, out i, out d, out a);
            Console.WriteLine(i());
            Console.WriteLine(i());
            Console.WriteLine(i());
            a(99);
            Console.WriteLine(d());

        }
    }

}

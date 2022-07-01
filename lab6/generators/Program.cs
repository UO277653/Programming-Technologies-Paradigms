using System;
using System.Linq;
using System.Diagnostics;
using generators;

namespace TPP.Laboratory.Functional.Lab06 {

    class Program {
        static void Main() {

            CompareFibonacci();
            
            //int i = 0;

            //var myFib = Fibonacci.InfiniteFibonacci();
            //myFib.First(); // First value of the IEnumerable
            //// myFib.Last(); // ?

            //foreach (int value in Fibonacci.InfiniteFibonacci()) {
            //    Console.Write(value + " ");
            //    if (++i == 10)
            //        break;
            //}
            //Console.WriteLine();

            //i = 0;
            //foreach (int value in Fibonacci.InfiniteFibonacci()) {
            //    Console.Write(value + " ");
            //    if (++i == 10)
            //        break;
            //}
            //Console.WriteLine();
        }

        static void CompareFibonacci()
        {
            const int fibonacciTerm = 50000;
            int result;

            var chrono = new Stopwatch();
            chrono.Start();
            result = FibonacciEager.Fibonacci(10000, fibonacciTerm).Last();
            chrono.Stop();
            long firstCallEager = chrono.ElapsedTicks;
            Console.WriteLine("Eager version. First invocation in {0:N} ticks. Result: {1}.", firstCallEager, result);

            chrono.Restart();
            result = FibonacciEager.Fibonacci(10000, fibonacciTerm).Last();
            chrono.Stop();
            long secondCallEager = chrono.ElapsedTicks;
            Console.WriteLine("Eager version. Second invocation in {0:N} ticks. Result: {1}.", secondCallEager, result);

            chrono.Restart();
            result = Fibonacci.FiniteFibonacci(fibonacciTerm).Last();
            chrono.Stop();
            long firstCallLazy = chrono.ElapsedTicks;
            Console.WriteLine("Lazy version. First invocation in {0:N} ticks. Result: {1}.", firstCallLazy, result);

            chrono.Restart();
            result = Fibonacci.FiniteFibonacci(fibonacciTerm).Last();
            chrono.Stop();
            long secondCallLazy = chrono.ElapsedTicks;
            Console.WriteLine("Lazy version. Second invocation in {0:N} ticks. Result: {1}.", secondCallLazy, result);
        }
    }
}

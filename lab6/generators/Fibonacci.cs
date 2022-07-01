using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab06 {

    static class Fibonacci {

        static internal IEnumerable<int> InfiniteFibonacci(int minimum, int maximum) { // Lazy version of Fibonacci
            int first = 1, second = 1;
            var counter = minimum;

            while (counter < minimum)
            {
                int addition = first + second;
                first = second;
                second = addition;
                counter++;
            }

            while (counter <= maximum)
            { // minimum < maximum
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
                counter++;
            }
        }

        static internal IEnumerable<int> FiniteFibonacci(int maximumTerm)
        {
            int first = 1, second = 1, term = 1;
            while (true)
            {
                yield return first;
                int addition = first + second; first = second;
                second = addition;
                if (term++ == maximumTerm) yield break;
            }
        }

    }



}

using System;
using System.Collections.Generic;
using System.Text;

namespace generators
{
    class FibonacciEager
    {
        static internal IEnumerable<int> Fibonacci(int minimum, int maximum)
        {

            LinkedList<int> res = new LinkedList<int>();
            int first = 1, second = 1;
            int counter = 1;
            while (counter < minimum)
            {
                int addition = first + second;
                first = second;
                second = addition;
                counter++;
            }

            while (counter < maximum - 1)
            {
                int addition = first + second;
                res.AddLast(addition);
                first = second;
                second = addition;
                counter++;
            }

            return res;
        }
    }
}

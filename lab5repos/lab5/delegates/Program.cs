using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace delegates
{
    public class Program
    {

        public static int Plus2(int x)
        {
            return x + 2;
        }

        delegate int MyFirstDelegate(int x); //  (Type of parameters) int -> int

        public static double Square(double x)
        {
            return x * x;
        }

        public static void MyFirstHigherOrderMethod(Func<int, int> other)
        {

        }

        static void Main(string[] args)
        {
            Func<int, int> some = Plus2;
            MyFirstDelegate a = Plus2;
            MyFirstHigherOrderMethod(some);
            Func<double, double> sq = Square;

            Show(Map<int, int>(some, new int[] { -1, 3, 9, -10}));

            Func<int, int> myFirstLambda = (int x) => x + 2;

            Show(Map<int, int>(myFirstLambda, new int[] { -1, 3, 9, -10 })); // Can also put x => x + 2
        }

        public static IEnumerable<TCodomain> Map<TDomain, TCodomain>(Func<TDomain, TCodomain> f, IEnumerable<TDomain> numbers) // Receives delegate as param
        {
            TCodomain[] numbersRes = new TCodomain[numbers.Count()];

            int position = 0;
            foreach (TDomain element in numbers)
                numbersRes[position++] = f(element);

            return numbersRes;
        }

        public static void Show<T>(IEnumerable<T> vector)
        {
            foreach(var element in vector)
            {
                Console.WriteLine(element);
            }
        }

        public static TDomain Reduce<TDomain, TElement>(IEnumerable<TElement> elements, Func<TDomain, TElement, TDomain> f, Predicate<TElement> p = null) // Example: TElement is person and TDomain an int
        {
            TDomain res = default(TDomain); // f is getAge

            foreach(var element in elements)
            {
                if(p != null)
                {
                    if (p(element))
                    {
                        res = f(res, element);
                    }
                }
                else
                {
                    res = f(res, element);
                }
            }

            return res;
        }

        public static TElement Find<TElement>(IEnumerable<TElement> elements, Predicate<TElement> p)
        {
            foreach(var element in elements)
            {
                if (p(element))
                {
                    return element;
                }
            }

            return default(TElement);
        }

        public static IEnumerable<TElement> Filter<TElement>(IEnumerable<TElement> elements, Predicate<TElement> p)
        {
            IEnumerable<TElement> elementsRes = new LinkedList<TElement>(); 
            foreach (var element in elements)
            {
                if (p(element))
                {
                    elementsRes.ToList().Add(element);
                }
            }

            return elementsRes;
        }
    }
}

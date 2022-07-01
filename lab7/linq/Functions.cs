using System.Linq;
using System.Collections.Generic;
using System;

namespace TPP.Laboratory.Functional.Lab07 {

    static public class Functions {

        public static IEnumerable<TResult> Map<TElement, TResult>(this IEnumerable<TElement> collection, Func<TElement, TResult> function) {

            //TResult[] result = new TResult[collection.Count()];
            //int pos = 0;
            //foreach(TElement element in collection)
            //{
            //    result[pos++] = function(element);
            //}
            //return result;

            foreach (var element in collection)
            {
                yield return function(element);
            }
            yield break;

        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(T element in collection)
            {
                action(element);
            }
        }

    }
}

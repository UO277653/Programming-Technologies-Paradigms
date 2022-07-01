using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab10
{

    internal class Summation {

        protected virtual void Add(IEnumerable<int> collection, int from, int to) {
            if (from > to)
                throw new ArgumentException("From cannot be greater than to");

            //lock (this)
            //{
                System.Threading.Interlocked.Add(ref this.value, collection.Skip(from).Take(to - from + 1).Aggregate(0L, (a, b) => a + b));
            //}
        }

        protected long value;
        internal long Value {
            get { return this.value; }
        }

        private int numberOfThreads;
        private IEnumerable<int> vector;

        internal Summation(int elements, int numberOfThreads) {
            if (numberOfThreads > elements)
                throw new ArgumentException("The number of threads is too high");
            this.numberOfThreads = numberOfThreads;
            this.vector = Enumerable.Range(1,elements);
            
        }

        internal long Compute() {
            int elementsPerThread = vector.Count() / numberOfThreads;
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++) {

                threads[i] = new Thread((object counter) => {
                    int iLocal = (int)counter;
                    this.Add(this.vector, iLocal * elementsPerThread,
                        iLocal < numberOfThreads - 1 ? // last iteration
                        (iLocal + 1) * elementsPerThread - 1 :
                        vector.Count() - 1);
                });
            }

            for (int i = 0; i < numberOfThreads; i++)
                threads[i].Start(i);
            foreach (var thread in threads)
                thread.Join();
            return this.Value;
        }
    }

}

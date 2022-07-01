using System;
using System.Threading;
using Lab09;

namespace TPP.Laboratory.Concurrency.Lab09 {

    public class Master {

        private BitcoinValueData[] vector;

        private int numberOfThreads;

        public Master(BitcoinValueData[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }

        public double ComputeNumber(string v) {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.vector.Length/numberOfThreads;
            for(int i=0; i < this.numberOfThreads; i++)
                workers[i] = new Worker(this.vector, 
                    i*itemsPerThread, 
                    (i<this.numberOfThreads-1) ? (i+1)*itemsPerThread-1: this.vector.Length-1 // last one
                    , v);

            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();
                
            }

            foreach (var thread in threads) {
                thread.Join();
            }

            double result = 0;
            foreach (Worker worker in workers) {
                result += worker.Result;
            }

            return result;
        }

    }

}

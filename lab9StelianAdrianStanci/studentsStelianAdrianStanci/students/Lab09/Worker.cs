using Lab09;
using System;

namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private BitcoinValueData[] vector;

        private int fromIndex, toIndex;

        private double result;

        private int value;

        internal double Result {
            get { return this.result; }
        }

        internal Worker(BitcoinValueData[] vector, int fromIndex, int toIndex, String value) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.value = Int32.Parse(value);
        }

        internal void Compute() {
            this.result = 0;
            for(int i= this.fromIndex; i<=this.toIndex; i++)
                this.result += this.vector[i].Value > value ? 1 : 0;

            //Console.WriteLine(result);
        }

    }

}

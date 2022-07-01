using System;
using TPP.Laboratory.Concurrency.Lab09;

namespace Lab09
{

    class Program
    {
        /*
         * This program processes Bitcoin value information obtained from the
         * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
         */
        static void Main(string[] args)
        {
            var data = Utils.GetBitcoinData();

            Master master = new Master(data, 1);
            DateTime before = DateTime.Now;
            double result = master.ComputeNumber(args[0]);
            DateTime after = DateTime.Now;
            Console.WriteLine(1 + ";" + result + ";" + (after - before).Ticks + ";");
            //Console.WriteLine("Result with one thread: {0:N2}.", result);
            //Console.WriteLine("Elapsed time: {0:N0} ticks.",
            //    (after - before).Ticks);

            int nThreads = 51;

            for (int i = 2; i < nThreads; i++)
            {
                master = new Master(data, i);
                before = DateTime.Now;
                result = master.ComputeNumber(args[0]);
                after = DateTime.Now;
                Console.WriteLine(i + ";" + result + ";" + (after - before).Ticks + ";");
                //Console.WriteLine("Elapsed time: {0:N0} ticks.",
                //    (after - before).Ticks);
            }

            GC.Collect();

            GC.WaitForFullGCComplete();
        }
    }
}

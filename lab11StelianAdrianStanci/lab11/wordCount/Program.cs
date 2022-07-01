using System;
using System.Diagnostics;
using TPP.Laboratory.Concurrency.Lab11;
using wordCount;
using System.Linq;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            CountSequential(args[0]);

            CountParallel(args[0]);
        }

        static int CountSequential(string word)
        {
            int nCount = 0;
            String text = Processing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = Processing.DivideIntoWords(text);

            Stopwatch crono = new Stopwatch();
            crono.Start();

            for (int i = 0; i < words.Length; i++)
            {
                if(words[i] == word)
                {
                    nCount++;
                }
            }

            crono.Stop();
            Console.WriteLine("\nNumber of times: " + nCount);
            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);

            return nCount;
        }

        static int CountParallel(string word)
        {
            int nCount = 0;

            String text = Processing.ReadTextFile(@"..\..\..\..\clarin.txt");
            string[] words = Processing.DivideIntoWords(text);

            

            Stopwatch crono = new Stopwatch();
            crono.Start();

            System.Threading.Tasks.Parallel.For(0, words.Length, (int i) =>
            {
                if (words[i] == word) { nCount++; }
            });

            crono.Stop();
            Console.WriteLine("\nNumber of times: " + nCount);
            Console.WriteLine("\nElapsed time: {0:N} milliseconds.", crono.ElapsedMilliseconds);
            return nCount;
        }
    }
}

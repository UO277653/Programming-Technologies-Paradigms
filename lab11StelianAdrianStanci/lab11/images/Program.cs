using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace TPP.Laboratory.Concurrency.Lab11 {

    class Program {

        static void Main() {
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            string[] files = Directory.GetFiles(@"..\..\..\..\pics", "*.jpg");
            string newDirectory = @"..\..\..\..\pics\rotated";
            Directory.CreateDirectory(newDirectory);

            List<int> myList = new List<int>();

            Parallel.For(0, files.Length, (int i) =>
            { // Can also use foreach
                string file = files[i];
                string fileName = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file))
                {
                    Console.WriteLine("Processing the file \"{0}\".", fileName);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDirectory, fileName));
                }
                lock(myList)
                    myList.Add(Thread.CurrentThread.ManagedThreadId);
            });

            //foreach (string file in files) {
            //    string fileName = Path.GetFileName(file);
            //    using (Bitmap bitmap = new Bitmap(file)) {
            //        Console.WriteLine("Processing the file \"{0}\".", fileName);
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(newDirectory, fileName));
            //    }
            //}
            chrono.Stop();

            Console.WriteLine(myList.Distinct().Count());
            Console.WriteLine("Elapsed time: {0:N} milliseconds.", chrono.ElapsedMilliseconds);

            
        }
    }

}

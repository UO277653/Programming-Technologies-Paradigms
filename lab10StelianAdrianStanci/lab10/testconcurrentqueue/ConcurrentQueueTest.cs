using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using linkedlist;
using ConcurrentQueue;
using System;

namespace testconcurrentqueue
{
    [TestClass]
    public class ConcurrentQueueTest
    {
        static ConcurrentQueue<int> queue;

        [ClassInitialize]
        public static void InitializeAllTheTests(TestContext testContext)
        {
            queue = new ConcurrentQueue<int>();
        }

        [TestMethod]
        public void TestEnqueue()
        {
            queue = new ConcurrentQueue<int>();

            Assert.IsTrue(queue.IsEmpty());

            Thread[] threads = new Thread[5];

            threads[0] = new Thread(() => queue.EnQueue(0));
            threads[1] = new Thread(() => queue.EnQueue(1));
            threads[2] = new Thread(() => queue.EnQueue(2));
            threads[3] = new Thread(() => queue.EnQueue(3));
            threads[4] = new Thread(() => queue.EnQueue(4));

            foreach (Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            Assert.AreEqual(5, queue.NumberOfElements);

            Console.WriteLine(queue.ToString());
        }

        [TestMethod]
        public void TestDequeue()
        {
            queue = new ConcurrentQueue<int>();

            Thread[] threads = new Thread[5];

            threads[0] = new Thread(() => queue.EnQueue(0));
            threads[1] = new Thread(() => queue.EnQueue(1));
            threads[2] = new Thread(() => queue.EnQueue(2));
            threads[3] = new Thread(() => queue.EnQueue(3));
            threads[4] = new Thread(() => queue.EnQueue(4));

            foreach (Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            Assert.AreEqual(5, queue.NumberOfElements);

            threads[0] = new Thread(() => queue.DeQueue());
            threads[1] = new Thread(() => queue.DeQueue());
            threads[2] = new Thread(() => queue.DeQueue());
            threads[3] = new Thread(() => queue.DeQueue());
            threads[4] = new Thread(() => queue.DeQueue());

            foreach (Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            Assert.IsTrue(queue.IsEmpty());

            Assert.AreEqual(0, queue.NumberOfElements);

            Console.WriteLine(queue.ToString());
        }

        [TestMethod]
        public void TestPeek()
        {
            queue = new ConcurrentQueue<int>();

            Thread[] threads = new Thread[2];

            threads[0] = new Thread(() => queue.EnQueue(0));
            threads[1] = new Thread(() => queue.EnQueue(1));

            foreach (Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            Assert.AreEqual(0, queue.Peek());

            Console.WriteLine(queue.ToString());
        }
    }
}

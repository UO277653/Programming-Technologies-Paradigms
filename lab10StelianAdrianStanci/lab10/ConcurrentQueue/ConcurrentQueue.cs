using System;
using linkedlist;

namespace ConcurrentQueue
{
    public class ConcurrentQueue<T>
    {

        private LinkedList<T> list = new LinkedList<T>();

        public int NumberOfElements
        {
            get
            {
                return list.NumberOfElements;
            }
        }

        /**
         * Number of elements
         * 
         * IsEmpty
         * 
         * Enqueue
         * 
         * Dequeue
         * 
         * Peek
         * **/

        // faltan locks?


        public bool IsEmpty()
        {
            lock (list)
            {
                return list.NumberOfElements == 0;
            }
        }

        public void EnQueue(T element)
        {
            lock (list)
            {
                list.Add(element);
            }
        }

        public T DeQueue()
        {
            T element;
            lock (list)
            {
                element = list.GetElement(0);

                list.Remove(0);

            }

            return element;
        }

        public T Peek()
        {
            lock (list)
            {
                return list.GetElement(0);
            }
        }

        public override String ToString()
        {
            return list.ToString();
        }
    }
}

using System;
using System.Text;
using System.Diagnostics;
using linkedlist;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    public class Stack<T> {

        private uint maxNumberOfElements;
        private LinkedList<Object> list;

        public bool IsEmpty
        {
            get
            {
                return list.NumberOfElements == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return list.NumberOfElements == maxNumberOfElements;
            }
        }

        public Stack(uint maxNumberOfElements)
        {
            if(maxNumberOfElements == 0 || maxNumberOfElements < 0)
            {
                throw new ArgumentException("Error: the number of elements has to be greater than 0");
            }

            list = new LinkedList<Object>();

            Debug.Assert(list.NumberOfElements == 0);

            this.maxNumberOfElements = maxNumberOfElements;

            Debug.Assert(Invariant());
        }

        public void Push(Object o)
        {
            if(o == null)
            {
                throw new ArgumentException("Error: cannot introduce a null object");
            }

            if(IsFull)
            {
                return;
            }

            list.Add(o);

            Debug.Assert(!(list.NumberOfElements > maxNumberOfElements));
            Debug.Assert(Invariant());
        }

        public Object Pop()
        {
            if (IsEmpty)
            {
                return default(T);
            }

            Object res = list.GetElement(list.NumberOfElements - 1);
            list.Remove(list.NumberOfElements - 1);
            Debug.Assert(Invariant());
            return res;
        }

        private bool Invariant()
        {
            if(list.NumberOfElements > maxNumberOfElements)
            {
                return false;
            }

            if (IsEmpty && IsFull)
            {
                return false;
            }

            return true;
        }

    }

}
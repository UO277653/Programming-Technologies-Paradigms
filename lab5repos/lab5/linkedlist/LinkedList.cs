using System;
using System.Collections;
using System.Collections.Generic;

namespace linkedlist
{
    static class ExtensionMethods
    {
        public static void Show<T>(this LinkedList<T> vector)
        {
            foreach (var element in vector)
            {
                Console.WriteLine(element);
            }
        }

        public static LinkedList<TCodomain> Map<TDomain, TCodomain>(this LinkedList<TDomain> numbers, Func<TDomain, TCodomain> f) // Receives delegate as param
        {
            LinkedList<TCodomain> numbersRes = new LinkedList<TCodomain>();

            foreach (TDomain element in numbers)
                numbersRes.Add(f(element));

            return numbersRes;
        }
    }

    class LinkedListEnum<T> : IEnumerator<T>, IEnumerator
    {
        public T[] objects;
        int position = -1;

        T IEnumerator<T>.Current { 
            get
            {
                return Current;
            }
        }

        object IEnumerator.Current {
            get
            {
                return Current;
            }
        }

        private T Current
        {
            get
            {
                try
                {
                    return objects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public LinkedListEnum(T[] objects)
        {
            this.objects = objects;
        }

        /*
        public LinkedListEnum(Object[] objects)
        {
            this.objects = objects;
        }*/

        void IDisposable.Dispose()
        {

        }

        bool IEnumerator.MoveNext()
        {
            position++;
            
            return (position < objects.Length);
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }
    }

    public class LinkedList<T> : IEnumerable<T>, IEnumerable
    {
        private Node<T> head;
        private int numberOfElements; // Private field

        public int NumberOfElements // Property
        {
            get
            {
                return this.numberOfElements;
            }
        }

        class Node<T>
        {
            internal T value;
            internal Node<T> next;

            internal Node(T value, Node<T> next)
            {
                this.value = value;
                this.next = next;
            }
        }

        public LinkedList()
        {
            this.numberOfElements = 0;
        }

        public void Add(T value)
        {
            if (this.numberOfElements == 0) // List is empty
            {
                this.head = new Node<T>(value, null);
            }
            else
            {
                Node<T> last = GetNode(Size() - 1);
                last.next = new Node<T>(value, null);
            }
            this.numberOfElements++;
        }

        private int Size()
        {
            return this.numberOfElements;
        }

        private Node<T> GetNode(int index)
        {
            if (index > Size() || index < 0) // Check parameters
            {
                return null;
            }

            int position = 0;
            Node<T> node = this.head;
            while (position < index)
            {
                node = node.next;
                position++;
            }
            return node;
        }

        public void Remove(int index)
        {
            if (this.numberOfElements == 0) return; // List is empty, nothing to remove

            if (index == 0)
            {
                this.head = this.head.next;
            }
            else
            {
                Node<T> previous = GetNode(index - 1);
                previous.next = previous.next.next;
            }
            this.numberOfElements--;
        }

        public T GetElement(int pos)
        {
            if (pos > Size() || pos < 0) // Check parameters
            {
                throw new ArgumentException("Invalid index!");
            }

            int position = 0;
            Node<T> node = this.head;
            while (position < pos)
            {
                node = node.next;
                position++;
            }
            return node.value;
        }

        public bool Contains(T element)
        {
            if (element == null) // Check parameters
            {
                throw new ArgumentException("Error: Invalid argument");
            }

            int position = 0;
            Node<T> node = this.head;
            while (position < Size())
            {
                if (node.value.Equals(element))
                {
                    return true;
                }

                node = node.next;
                position++;
            }
            return false;
        }

        public override string ToString()
        {
            string res = "";
            int position = 0;
            Node<T> node = head;

            if (node == null)
            {
                return "";
            }

            while (position < numberOfElements)
            {
                res += node.value + " ";
                node = node.next;
                position++;
            }

            res += "\n";

            return res;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            T[] objects = new T[numberOfElements];

            for(int i = 0; i < numberOfElements; i++)
            {
                objects[i] = GetElement(i);
            }

            return new LinkedListEnum<T>(objects);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Object[] objects = new Object[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                objects[i] = GetElement(i);
            }

            return new LinkedListEnum<Object>(objects);
        }
    }
}


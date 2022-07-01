using System;
using System.Collections;
using System.Collections.Generic;

namespace linkedlist
{
    //static class ExtensionMethods
    //{
        //public static void Show<T>(this LinkedList<T> vector)
        //{
        //    foreach (var element in vector)
        //    {
        //        Console.WriteLine(element);
        //    }
        //}

        //public static LinkedList<TCodomain> Map<TDomain, TCodomain>(this LinkedList<TDomain> numbers, Func<TDomain, TCodomain> f) // Receives delegate as param
        //{
        //    LinkedList<TCodomain> numbersRes = new LinkedList<TCodomain>();

        //    foreach (TDomain element in numbers)
        //        numbersRes.Add(f(element));

        //    return numbersRes;
        //}

        ///**
        // * Find
        // * Filter
        // * Reduce
        // * Invertto, combined with Reduce, allow reducing from right to lef
        // * Map
        // * Foreach
        // * **/

        //public static TDomain Reduce<TDomain, TElement>(this LinkedList<TElement> elements, Func<TDomain, TElement, TDomain> f, Predicate<TElement> p = null)
        //{
        //    TDomain res = default(TDomain);

        //    foreach (var element in elements)
        //    {
        //        if (p != null)
        //        {
        //            if (p(element))
        //            {
        //                res = f(res, element);
        //            }
        //        }
        //        else
        //        {
        //            res = f(res, element);
        //        }
        //    }

        //    return res;
        //}

        //public static TElement Find<TElement>(this LinkedList<TElement> elements, Predicate<TElement> p)
        //{
        //    foreach (var element in elements)
        //    {
        //        if (p(element))
        //        {
        //            return element;
        //        }
        //    }

        //    return default(TElement);
        //}

        //public static IEnumerable<TElement> Filter<TElement>(this LinkedList<TElement> elements, Predicate<TElement> p)
        //{
        //    LinkedList<TElement> elementsRes = new LinkedList<TElement>();
        //    foreach (var element in elements)
        //    {
        //        if (p(element))
        //        {
        //            elementsRes.Add(element);
        //        }
        //    }

        //    return elementsRes;
        //}

        //public static void ForEach<T>(this LinkedList<T> collection, Action<T> action)
        //{
        //    foreach (T element in collection)
        //    {
        //        action(element);
        //    }
        //}

        //public static void Invert<T>(this LinkedList<T> collection)
        //{
            
        //}
    //}

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

        public void Show(LinkedList<T> vector)
        {
            foreach (var element in vector)
            {
                Console.WriteLine(element);
            }
        }

        public LinkedList<TCodomain> Map<TCodomain>(Func<T, TCodomain> f) // Receives delegate as param
        {
            LinkedList<TCodomain> numbersRes = new LinkedList<TCodomain>();

            foreach (T element in this)
                numbersRes.Add(f(element));

            return numbersRes;
        }

        public TDomain Reduce<TDomain>(Func<TDomain, T, TDomain> f, TDomain seed = default(TDomain))
        {
            TDomain res = seed;

            foreach (var element in this)
            {
                res = f(res, element);
            }

            return res;
        }

        public T Find(Predicate<T> p)
        {
            foreach (var element in this)
            {
                if (p(element))
                {
                    return element;
                }
            }

            return default(T);
        }

        public IEnumerable<T> Filter(Predicate<T> p)
        {
            LinkedList<T> elementsRes = new LinkedList<T>();
            foreach (var element in this)
            {
                if (p(element))
                {
                    elementsRes.Add(element);
                }
            }

            return elementsRes;
        }

        public void ForEach(Action<T> action)
        {
            foreach (T element in this)
            {
                action(element);
            }
        }

        public IEnumerable<T> Invert()
        {
            LinkedList<T> res = new LinkedList<T>();

            for(int i = Size() - 1; i >= 0; i--)
            {
                res.Add(GetElement(i));
            }

            return res;
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

        public Boolean Remove(T element)
        {
            if (this.numberOfElements == 0) return false; // List is empty, nothing to remove

            if (element == null) return false;

            int index = 0;
            Boolean found = false;

            if (this.head.value.Equals(element))
            {
                this.head = this.head.next;
                found = true;
            }
            else
            {
                while (index < (Size() - 1) && !found) //  && !found
                {
                    index++;
                    if (GetNode(index).value.Equals(element))
                    {
                        Node<T> previous = GetNode(index - 1);

                        if(previous.next.next == null)
                        {
                            previous.next = null;
                            found = true;
                        }
                        else
                        {
                            previous.next = previous.next.next;
                            found = true;
                        }
                    }
                }
            }


            if (found)
            {
                this.numberOfElements--;
            }

            return found;
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


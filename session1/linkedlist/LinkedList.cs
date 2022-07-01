using System;

namespace linkedlist
{
    public class LinkedList
    {
        private Node head;
        private int numberOfElements; // Private field

        public int NumberOfElements // Property
        {
            get
            {
                return this.numberOfElements;
            }
        }

        class Node
        {
            internal int value;
            internal Node next;

            internal Node(int value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }

        public LinkedList()
        {
            this.numberOfElements = 0;
        }

        public void Add(int element)
        {
            if (this.numberOfElements == 0) // List is empty
            {
                this.head = new Node(element, null);
            }
            else
            {
                Node last = GetNode(Size() - 1);
                last.next = new Node(element, null);
            }
            this.numberOfElements++;
        }

        private int Size()
        {
            return this.numberOfElements;
        }

        private Node GetNode(int index)
        {
            if(index > Size() || index < 0) // Check parameters
            {
                return null;
            }

            int position = 0;
            Node node = this.head;
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
                Node previous = GetNode(index - 1);
                previous.next = previous.next.next;
            }
            this.numberOfElements--;
        }

        public int GetElement(int pos)
        {
            if (pos > Size() || pos < 0) // Check parameters
            {
                throw new ArgumentException("Invalid index!");
            }

            int position = 0;
            Node node = this.head;
            while (position < pos)
            {
                node = node.next;
                position++;
            }
            return node.value;
        }

        public override string ToString()
        {
            string res = "";
            int position = 0;
            Node node = head;

            if(node == null)
            {
                return "";
            }

            while (position < numberOfElements)
            {
                res += node.value;
                node = node.next;
                position++;
            }

            res += "\n";

            return res;
        }
    }
}


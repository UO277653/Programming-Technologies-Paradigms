using System;
using linkedlist;

namespace use.linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            Console.WriteLine(list.ToString()); // Testing add

            list.Remove(0);
            Console.WriteLine(list.ToString()); // Testing remove

            Console.WriteLine(list.GetElement(0).ToString()); // Testing GetElement()
        }
    }
}

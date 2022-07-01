using System;

namespace parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 100;
            Swap(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);

            // Write a method for asking the user some data 
            String name = null;
            String surname = null;
            String student_id = null;

            AskData(out name, out surname, out student_id);
            Console.WriteLine("The user has entered the following data: name {0}, surname {1}, UO {2}", name, surname, student_id);
        }

        private static void AskData(out String name, out String surname, out String student_id)
        {
            name = Console.In.ReadLine();
            surname = Console.In.ReadLine();
            student_id = Console.In.ReadLine();
        }

        private static void Swap(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }
    }
}

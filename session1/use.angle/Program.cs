using System;
using angle;
using TPP.Laboratory.ObjectOrientation.Lab01;

namespace use.angle
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle ang = new Angle(Math.PI);

            Console.WriteLine("Angle (radians): {0}", ang.Radians);
            Console.WriteLine("Angle (degrees): {0}", ang.Degrees);
            Console.WriteLine("Sine: {0}", ang.Sine());
            Console.WriteLine("Cosine: {0}", ang.Cosine());
            Console.WriteLine("Tangent: {0}", ang.Tangent());

            PersonTO jose = new PersonTO() { FirstName = "Jose", Surname = "Quiroga"}; // Override ToString method?

            Console.WriteLine(jose.ToString());

        }
    }
}

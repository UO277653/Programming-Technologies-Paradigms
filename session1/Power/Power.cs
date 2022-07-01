
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab01 {

    /// <summary>
    /// Class that computes the power of a number
    /// </summary>
    class Power {

        static void Main() {
            double theBase = 2; // was uint, caused overflow
            double exponent = 32;

            double result = 1;

            if (theBase == 0) {
                Console.WriteLine("Power: 0.");
                return;
            }

            while (exponent > 0) {
                result *= theBase;
                exponent--;
            }

            Console.WriteLine("Power: {0}.", result);
        }
    }

}


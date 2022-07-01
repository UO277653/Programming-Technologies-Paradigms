using System;

namespace angle
{
    public class Angle
    {

        private double radians;

        public double Radians { 
            get {
                return this.radians;
            }

            set 
            {
                this.radians = value;
            }
        }

        public double Degrees
        {
            get
            {
                return this.radians / Math.PI * 180;
            }
        }

        public Angle(double rad) {
            this.radians = rad;
            Console.WriteLine("Angle created with radians {0}",rad);
        }



        public double Sine()
        {
            return Math.Sin(this.radians);
        }

        public double Cosine()
        {
            return Math.Cos(this.radians);
        }

        public double Tangent()
        {
            return Sine() / Cosine();
        }
    }
}

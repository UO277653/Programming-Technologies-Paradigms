using System;

namespace vector
{
    public class Vector
    {
        private const int INITIAL_N = 10;

        private int size;
        private int[] numbers;

        public int Size { 
            get {
                return this.size;
            } 
        }

        public Vector()
        {
            this.size = 0;
            numbers = new int[INITIAL_N];
        }

        public Vector(int Size)
        {
            this.size = 0;
            numbers = new int[Size];
        }

        public void Add(int value)
        {
            if (IsFull())
            {
                Resize();
            }

            numbers[Size] = value;
            size++;
        }

        private bool IsFull()
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 0) { return false; }
            }

            return false;
        }

        private void Resize()
        {
            int[] res = new int[numbers.Length * 2];

            for (int i = 0; i < numbers.Length; i++)
            {
                res[i] = numbers[i];
            }

            numbers = res;
        }

        public int GetElement(int n)
        {
            if(n >= Size || n < 0)
            {
                throw new ArgumentException("Error: n is not a valid number");
            }

            return numbers[n];
        }

        public void SetElement(int pos, int value)
        {
            if (pos >= Size || pos < 0)
            {
                throw new ArgumentException("Error: n is not a valid number");
            }

            numbers[pos] = value;
        }
    }
}

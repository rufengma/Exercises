using System;

namespace Exercise4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please input 2 values for a and b, seperated by space:");
            string input=Console.ReadLine();
            string[] arguments = input.Split(' ');
            int a = Convert.ToInt32(arguments[0]);
            int b = Convert.ToInt32(arguments[1]);
            for (int i = a + 1; i < b; ++i)
            {

                // number of digits calculation
                int x = i;
                int n = 0;
                while (x != 0)
                {
                    x /= 10;
                    ++n;
                }

                // compute sum of nth power of
                // its digits
                int pow_sum = 0;
                x = i;
                while (x != 0)
                {
                    int digit = x % 10;
                    pow_sum += (int)Math.Pow(digit, n);
                    x /= 10;
                }

                // checks if number i is equal
                // to the sum of nth power of
                // its digits
                if (pow_sum == i)
                    Console.Write(i + " ");
            }
        }
    }
}
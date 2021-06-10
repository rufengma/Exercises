using System;

namespace Exercise6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter number of rows for the diamond:");
            int rows = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }

            for (int i = rows - 1; i >= 1; i--)
            {
                for (int j = 1; j <= rows - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }
    }
}

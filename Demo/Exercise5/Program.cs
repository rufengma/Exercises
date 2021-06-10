using System;

namespace Exercise5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number of rows:");
            int rows = Convert.ToInt32(Console.ReadLine());
            int p = 0, lastInt = 0;
            for (int i = 1; i <= rows; i++)
            {
                for (p = 1; p <= i; p++)
                {
                    if (lastInt == 1)
                    {
                        Console.Write("0");
                        lastInt = 0;
                    }
                    else if (lastInt == 0)
                    {
                        Console.Write("1");
                        lastInt = 1;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}

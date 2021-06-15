using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Square
    {
        public static void Main()
        {

            Console.Write("Enter a number =>");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a > 0 && a <= 10)
            {
                for (int i = 0; i < 6; i++)
                {
                    a = a << 1;//So in your example, (1<<1) is 1*(2^1) is 2, (1<<8) is 1*(2^8) is 256
                    Console.Write("{0},", a);
                }
            }
            Console.ReadKey();
        }
    }
}


using System;

namespace Exercise2
{
    class Arithmetic {
        int a = 0, b = 2;
        public static void Addition(int a, int b)
        {
            int c = 0;
            c = a + b;
            Console.WriteLine(c);
        }
        public static void Subtraction(int a, int b)
        {
            int c = 0;
            c = a - b;
            Console.WriteLine(c);
        }
        public static void Multiplication(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        public static void Division(int a, int b)
        {
            float c =1;
            if (b == 0)
            {
                Console.WriteLine("Zero cannot be a Denominator.");
            }
            else
            {
                c = a / b;
                Console.WriteLine(c);
            } 
        }

    }
    /*
     * write small test cases
     */
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Choose an arithmetic type #: 1, Addition;2, Subtraction;3, Multiplication;4, Division");
            int calculator = Convert.ToInt32(Console.ReadLine());
            int a = 0, b = 2;
            Console.WriteLine("a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("b = ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The result is: ");
            switch (calculator) {
                case 1:
                    Arithmetic.Addition(a, b);
                    break;
                case 2:
                    Arithmetic.Subtraction(a, b);
                    break;
                case 3:
                    Arithmetic.Multiplication(a, b);
                    break;
                case 4:
                    Arithmetic.Division(a, b);
                    break;
            }
        }
    }

}

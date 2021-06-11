﻿using System;
namespace Exercise1
{
    class Rectangle
    {
        double length = 1;
        double width = 1;
        public void GetData()
        {
        again:
            Console.WriteLine("enter length:");
            length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter width: ");
            width = Convert.ToInt32(Console.ReadLine());
            if (length < 0 || length > 20 || width < 0 || width > 20)
            {
                Console.WriteLine("Please enter length and width between 0 and 20");
                goto again;
            }

        }
        public double GetArea()
        {
            return length * width;
        }
        public double GetPerimeter()
        {
            return 2 * (length + width);
        }
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.GetData();
            Console.WriteLine("Area is : "+r.GetArea());
            Console.WriteLine("Perimeter is: " + r.GetPerimeter());
        }
    }

}

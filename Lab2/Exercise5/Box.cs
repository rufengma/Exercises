using System;

namespace Exercise5
{
    class Box
    {
        public double length=0, breadth=0, height=0;
        public double getVolume()
        {
            return length * breadth * height;
        }
        public void setLength(double len)
        {
            length = len;
        }

        public void setBreadth(double bre)
        {
            breadth = bre;
        }

        public void setHeight(double hei)
        {
            height = hei;
        }


    }
    class Mainentry {
        public static void Main(string[] args)
        {
            Box box = new Box();

            Console.WriteLine("Initial volume is "+box.getVolume());
            Console.WriteLine("Enter the length");
            double l = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the breadth");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Height");
            double h = Convert.ToDouble(Console.ReadLine());
            box.setLength(l);
            box.setBreadth(b);
            box.setHeight(h);
            Console.WriteLine("Now the volume is " + box.getVolume());
        }
    }
}

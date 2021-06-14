using System;

namespace Exercise1
{
    public abstract class Shape1
    {
        protected double R, L, B;
        public abstract double Area();
        public abstract double Circumference();
    }

    public class Circle : Shape1
    {
        public override double Area()
        {
            Console.Write("Enter Radiu: ");
            R = Convert.ToDouble(Console.ReadLine());
            return 3.14 * R * R;
        }
        public override double Circumference()
        {
            return 2 * 3.14 * R;
        }

    }
    public class Rectangle : Shape1
    {
        public override double Area()
        {
            Console.Write("Enter the length: ");
            L = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Breadth: ");
            B = Convert.ToDouble(Console.ReadLine());
            return L * B;
        }
        public override double Circumference()
        {
            return 2 * (L + B);
        }

    }


    class MainClass
    {
        public static void Calculate(Shape1 S)
        {

            Console.WriteLine("Area : {0}", S.Area());
            Console.WriteLine("Circumference : {0}", S.Circumference());

        }
        public static void Main(string[] args)
        {
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            Calculate(circle);
            Calculate(rectangle);
        }
    }

}

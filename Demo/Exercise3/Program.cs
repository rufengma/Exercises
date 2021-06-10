using System;

namespace Exercise3
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please input a string for a reverse: ");
            string s1= Console.ReadLine();
            char[] charArray = s1.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine("new string is :"+ new string(charArray));

        }
    }
}

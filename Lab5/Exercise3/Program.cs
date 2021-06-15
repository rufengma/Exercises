using System;

namespace Exercise3
{
    class MainClass
    {
        static void f(int s){
            s+=1;
        }
        static void Main(string[] args) {
            int s = 5;
            f(s);
            Console.WriteLine(s);
        }
    }
}

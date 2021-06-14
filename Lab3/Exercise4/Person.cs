using System;

namespace Exercise4
{
    public class Person
    {
        protected int age;
        public Person()
        {
            age = 15;
        }
        public void SetAge(int n)
        {
            age = n;
        }
        public void Greet() {
            Console.WriteLine("Hello");
        }
    }
}

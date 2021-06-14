using System;
namespace Exercise4
{
    public class Student:Person
    {
        public Student()
        {
        }
        public void GoToClasses() {
            Console.WriteLine("I'm going to class");
        }
        public void ShowAge() {
            Console.WriteLine("My age is " + age + " years old");
        }
    }

}

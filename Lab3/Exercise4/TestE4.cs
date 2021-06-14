using System;
namespace Exercise4
{
    public class TestE4
    {
        static void Main()
        {
            Person person = new Person();
            Student student = new Student();
            Teacher teacher = new Teacher();
            person.Greet();
            student.SetAge(21);
            student.Greet();
            student.ShowAge();
            teacher.SetAge(30);
            teacher.Greet();
            teacher.Explain();
        }
    }
}

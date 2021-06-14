using System;
namespace Exercise2
{
    public class Door
    {
        protected string color;

        public Door()
        {
            color = "Brown";
        }
        public Door(string color)
        {
            this.color = color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public void ShowData()
        {
            Console.WriteLine("I am a door, my color is {0}.", color);
        }
    }
}

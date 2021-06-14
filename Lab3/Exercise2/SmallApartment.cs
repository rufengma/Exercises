using System;
namespace Exercise2
{
    public class SmallApartment:House
    {
        public SmallApartment():base(50)
        {
        }
        public override void ShowData()
        {
            Console.WriteLine("I am an apartment, my area is " +
                area + " m2");
        }

    }

}

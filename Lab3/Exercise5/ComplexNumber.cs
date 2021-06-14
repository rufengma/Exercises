using System;

namespace Exercise5
{
    public class ComplexNumber
    {
        public int real=2;
        public int imaginary=3;
        public void SetImaginary(int n) {
            imaginary = n;
        }
        public void SetReal(int n)
        {
            real = n;
        }
        public ComplexNumber() {
        }
        public ComplexNumber(int a, int b) {
            SetImaginary(b);
            SetReal(a);
        }
        public override string ToString() {
            string x = "("+real+","+imaginary+")";
            return x;
        }
        public double GetMagnitude() {
            double y = Math.Sqrt(real * real + imaginary * imaginary);
            return y;
        }
        public int Add(ComplexNumber a) {
            return a.real+a.imaginary;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_interface
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private double re, im;

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex Add(MyComplex b)
        {
            return new MyComplex(re + b.re, im + b.im);
        }

        public MyComplex Subtract(MyComplex b)
        {
            return new MyComplex(re - b.re, im - b.im);
        }

        public MyComplex Multiply(MyComplex b)
        {
            return new MyComplex(re * b.re - im * b.im, re * b.im + im * b.re);
        }

        public MyComplex Divide(MyComplex b)
        {
            if (b.re * b.re + b.im * b.im == 0)
            {
                throw new DivideByZeroException("Can't divide by zero");
            }
            return new MyComplex((re * b.re + im * b.im) / (b.re * b.re + b.im * b.im),
                (im * b.re - re * b.im) / (b.re * b.re + b.im * b.im));
        }

        public override string ToString()
        {
            return im > 0 ? $"{re}+{im}i" : $"{re * -1}-{im * -1}i";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace OOP_interface
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nom, denom;

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new ArgumentException("Divide by zero exception");
            }
            BigInteger nsd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(nom), BigInteger.Abs(denom));
            this.nom = nom / nsd;
            this.denom = denom / nsd;
            if (this.denom < 0)
            {
                this.nom *= -1;
                this.denom *= -1;
            }
        }

        private static BigInteger MakeBigInteger(int n)
        {
            return n;
        }

        public MyFrac(int nom, int denom) : this(MakeBigInteger(nom), MakeBigInteger(denom))
        {
        }

        public MyFrac Add(MyFrac b)
        {
            return new MyFrac(nom * b.denom + b.nom * denom, denom * b.denom);
        }
        public MyFrac Subtract(MyFrac b)
        {
            return new MyFrac(nom * b.denom - b.nom * denom, denom * b.denom);
        }

        public MyFrac Divide(MyFrac b)
        {
            return new MyFrac(nom * b.denom, denom * b.nom);
        }

        public MyFrac Multiply(MyFrac b)
        {
            return new MyFrac(nom * b.nom, denom * b.denom);
        }

        public int CompareTo(MyFrac that)
        {
            return (nom * that.denom).CompareTo(that.nom * denom);
        }

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }
    }
}

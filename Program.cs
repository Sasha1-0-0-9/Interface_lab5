using System;
using System.Collections.Generic;

namespace OOP_interface
{
    class Program
    {
        static void SortFracsTest()
        {
            List<MyFrac> mfList = new List<MyFrac>{
                new MyFrac(10, 4),
                new MyFrac(2, 4),
                new MyFrac(10, -27),
                new MyFrac(1231, 512),
                new MyFrac(4, 8),
                new MyFrac(1, 1),
                new MyFrac(2, 1),
            };
            Console.WriteLine("Before sorting");
            PrintFrac(mfList);
            mfList.Sort();
            Console.WriteLine("After sorting");
            PrintFrac(mfList);
        }

        static void PrintFrac(List<MyFrac> myFracs)
        {
            myFracs.ForEach(frac =>
            {
                Console.Write(frac + " ");
            });
            Console.WriteLine();
        }

        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b);
            curr = curr.Add(curr);
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)=(a^2-b^2)/a+b with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine(" = = = ");
            T aInSquared = a.Multiply(a);
            Console.WriteLine("a^2 = " + aInSquared);
            T bInSquared = b.Multiply(b);
            Console.WriteLine("b^2 = " + bInSquared);
            T numerator = aInSquared.Subtract(bInSquared);
            Console.WriteLine("a^2 - b^2 = " + numerator);
            T denominator = a.Add(b);
            Console.WriteLine("a + b = " + denominator);
            Console.WriteLine("(a ^ 2 - b ^ 2)/(a + b) = " + numerator.Divide(denominator));
            Console.WriteLine("=== Finishing testing (a-b)=(a^2-b^2)/a+b with a = " + a + ", b = " + b + " ===");
        }
        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            TestSquaresDifference(new MyFrac(1, 6), new MyFrac(1, 14));
            TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));
            SortFracsTest();
            Console.ReadKey();
        }
    }
}

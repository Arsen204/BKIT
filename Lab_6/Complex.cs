using System;

namespace Lab_6
{
    using complex = System.ValueTuple<double, double>;
    public static class Complex
    {
        public static complex ComplexSum(complex x, complex y)
        {
            return ((x.Item1 + y.Item1), (x.Item2 + y.Item2));
        }

        public static complex ComplexMultiply(complex x, complex y)
        {
            return ((x.Item1 * y.Item1 + x.Item2 * y.Item2), (x.Item1 * y.Item2 + x.Item2 * y.Item1));
        }

        public static complex ComplexDivision(complex x, complex y)
        {
            var num = ComplexMultiply(x, (y.Item1, -y.Item2));
            double del = y.Item1 * y.Item1 + y.Item2 * y.Item2;
            return (num.Item1 / del, num.Item2 / del);
        }

        public static double ComplexABS(complex complex)
        {
            return Math.Sqrt(complex.Item1 * complex.Item1 + complex.Item2 * complex.Item2);
        }
    }
}

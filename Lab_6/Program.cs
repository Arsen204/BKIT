using System;
using System.Reflection;

namespace Lab_6
{
    using complex = System.ValueTuple<double, double>;
    class MainClass
    {
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);

            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        //delegate string DetermineResistance((double, double) complex1, (double,double) complex2, string units);

        static string ParallelConnection(complex complex1, complex complex2, string units)
        {
            var sum = Complex.ComplexSum(complex1, complex2);
            var mult = Complex.ComplexMultiply(complex1, complex2);
            var div = Complex.ComplexDivision(mult, sum);

            return Complex.ComplexABS(div).ToString() + "\t" + units;
        }

        //здесь исползуем обобщенный делегат Func<>
        static void PrintCalculatedResistance(complex complex1, complex complex2,
            string units, Func<complex, complex, string, string> func)
        {
            Console.Write(func(complex1, complex2, units));
            Console.WriteLine("\tCalculations finished...");
        }

        public static void Main()
        {
            //передаем функцию через делегат
            PrintCalculatedResistance((21.1f, 12.3f), (1.23f, -2.12f), "mA", ParallelConnection);

            //передаем лямбда-функцию в качестве параметра
            PrintCalculatedResistance((23.17f, 0f), (0f, 0.002f), "A", (complex complex1,
                complex complex2, string units) =>
            {
                return Complex.ComplexABS(Complex.ComplexSum(complex1, complex2)).ToString() + "\t" + units;
            });

            Console.WriteLine("\n_________________________\n");

            var car = new ReflextionTest("Mercedes", "Black");
            Type t = car.GetType();

            Console.WriteLine("\nConstructors:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nMethods:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nProperties:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nProperties with attribute:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }

            object Result = t.InvokeMember("Description", System.Reflection.BindingFlags.InvokeMethod, null, car, new object[] { });
            Console.WriteLine("\nDescription ->\n" + Result);
        }
    }
}

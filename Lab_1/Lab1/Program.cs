using System;

namespace Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Вардумян Арсен ИУ5-31Б\n");
            int a = 0 , b = 0, c = 0;

            if (args.Length == 0)
            { 
                Console.WriteLine("Введите А:");
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Недопустимый формат, введите заново...");
                }

                Console.WriteLine("Введите B:");
                while (!int.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Недопустимый формат, введите заново...");
                }

                Console.WriteLine("Введите C:");
                while (!int.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Недопустимый формат, введите заново...");
                }
            }
            else
            {
                if (!(int.TryParse(args[0], out a) && int.TryParse(args[1], out b) && int.TryParse(args[2], out c)))
                {
                    Console.WriteLine("Неверный формат...");
                }
            }

            int D = b * b - 4 * a * c;

            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет...");
            }
            else
            {
                if (D == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Корень уравнения:{-b / (2 * a):f2}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine($"Корни уравнения:{x1:f2} и {x2:f2}");
                }
            }
        }
    }
}

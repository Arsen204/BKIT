using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ArrayList");
            Console.ForegroundColor = ConsoleColor.Black;

            var arr = new ArrayList
            {
                new Rectangle(6, 4),
                new Rectangle(5, 2),
                new Circle(10),
                new Square(7),
                new Rectangle(13, 7),
                new Circle(11)
            };

            arr.Sort();

            foreach (Shape item in arr)
            {
                item.Print();
            }

            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nShapesList");
            Console.ForegroundColor = ConsoleColor.Black;

            var ShapesList = new List<Shape>
            {
                new Rectangle(12, 3),
                new Square(2),
                new Circle(6.6),
                new Square(17),
                new Circle(20)
            };

            ShapesList.Sort();

            foreach (Shape item in ShapesList)
            {
                item.Print();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nМатрица");
            Console.ForegroundColor = ConsoleColor.Black;

            SparseMatrix<Shape> matrix = new SparseMatrix<Shape>(3, 3, 3,
            new FigureMatrixCheckEmpty());

            matrix[0, 0, 0] = ShapesList[0];
            matrix[1, 1, 1] = ShapesList[1];
            matrix[2, 2, 2] = ShapesList[2];

            Console.WriteLine(matrix.ToString());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nСтек фигур");
            Console.ForegroundColor = ConsoleColor.Black;

            SimpleStack<Shape> ShapeStack = new SimpleStack<Shape>();
            ShapeStack.Push(ShapesList[0]);
            ShapeStack.Push(ShapesList[3]);
            ShapeStack.Push(ShapesList[2]);
            ShapeStack.Push(ShapesList[2]);
            ShapeStack.Push(ShapesList[1]);
            ShapeStack.Push(ShapesList[0]);

            while (ShapeStack.Count > 0)
            {
                Console.WriteLine(ShapeStack.Pop());
            }
        }
    }
}

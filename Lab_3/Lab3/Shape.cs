using System;
namespace Lab3
{
    public abstract class Shape : IComparable
    {
        public abstract double Area();

        public int CompareTo(object obj)
        {
            Shape x = obj as Shape;

            if (x != null)
                return Area().CompareTo(x.Area());
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    public class Rectangle : Shape
    {
        public double height { get; private set; }

        public double width { get; private set; }

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double Area()
        {
            return height * width;
        }

        public override string ToString()
        {
            return $"Прямоугольник с высотой {height}, шириной {width} и площадью {this.Area()}";
        }
    }

    public class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {

        }

        public override string ToString()
        {
            return $"Квадрат со стороной {height} и площадью {this.Area()}";
        }
    }

    public class Circle : Shape
    {
        public double R { get; private set; }

        public Circle(double R)
        {
            this.R = R;
        }

        public override double Area()
        {
            return Math.PI * R * R;
        }

        public override string ToString()
        {
            return $"Круг с радиусом {R} и площадью {this.Area()}";
        }
    }

    class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Shape>
    {
        public Shape getEmptyElement()
        {
            return null;
        }
        
        public bool checkEmptyElement(Shape element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }
}

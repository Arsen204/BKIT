using System;

namespace Lab2
{
    public abstract class Shape
    {
        public abstract double Area();
      
    }

    public class Rectangle: Shape, IPrint
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

        public void Print()
        {
            Console.WriteLine(this.ToString());
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

    public class Circle : Shape, IPrint
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

        public void Print()
        {
            Console.WriteLine(this.ToString()); ;
        }
    }

    public interface IPrint
    {
        void Print();
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Shape[] shapes = new Shape[3];

            shapes[0] = new Rectangle(3,1);
            shapes[1] = new Square(1);
            shapes[2] = new Circle(3);

            ((Rectangle)shapes[0]).Print();
            ((Square)shapes[1]).Print();
            ((Circle)shapes[2]).Print();
 
        }
    }
}

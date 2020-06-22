using System;

namespace Learning_Interfaces
{
    class Circle : IShape
    {
        double r;
        const double pi = 3.14;
        public Circle(double r)
        {
            this.r = r;
        }

        public double Area()
        {
            return pi * r * r;
        }
    }
    class Square : IShape
    {
        double k;
        public Square(double k)
        {
            this.k = k;
        }
        public double Area()
        {
            return k * k;
        }
    }
    class Trapez : IShape
    {
        double a;
        double b;
        double h;

        public Trapez(double a, double b, double h)
        {
            this.a = a;
            this.b = b;
            this.h = h;
        }
        public double Area()
        {
            return area();
        }
        public double HalfArea()
        {
            return area() * 0.5;
        }

        private double area()
        {
            return 0.5 * (a + b) * h;
        }
    }

    class Triangle : IShape
    {
        double t;
        double h;
        public Triangle(double t, double h)
        {
            this.t = t;
            this.h = h;
        }
        public double Area()
        {
            return 0.5 * t * h;
        }
    }
    interface IShape
    {
        double Area();
    }
    class Program
    {
        public static void PrintShape(IShape shape)
        {
            Console.WriteLine(shape.Area());
        }

        //public static void PrintAll(Object o)
        //{
        //    string className = o.GetType().Name.ToString();
        //    o.GetType().GetMethods();
        //    Console.WriteLine(className);
        //}
        static void Main(string[] args)
        {
            Circle c = new Circle(2);
            //Console.WriteLine(c.Area());
            //PrintShape(c);
            Square square = new Square(4);
            //Console.WriteLine(square.Area());
            Triangle triangle = new Triangle(8, 4);
            Trapez trapez = new Trapez(3, 2, 4);


            PrintShape(square);
            PrintShape(c);
            PrintShape(triangle);
            PrintShape(trapez);
            Console.ReadKey();

        }
    }
}

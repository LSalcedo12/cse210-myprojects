using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s = new Square("Red", 5);
        Rectangle r = new Rectangle("Blue", 4, 6);
        Circle c = new Circle("Green", 3);

        shapes.Add(s);
        shapes.Add(r);
        shapes.Add(c);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}
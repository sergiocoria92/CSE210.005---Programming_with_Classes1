using System;
using System.Collections.Generic;

namespace ShapesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Square("Red", 5));
            shapes.Add(new Rectangle("Blue", 4, 6));
            shapes.Add(new Circle("Green", 3));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Shape Color: {shape.Color}, Area: {shape.GetArea():0.00}");
            }
        }
    }
}

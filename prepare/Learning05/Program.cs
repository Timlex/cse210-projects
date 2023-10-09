using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Create and add shapes to the list
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        // Iterate through the list of shapes and display their color and area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}

// Base Shape class
abstract class Shape
{
    private string color;

    public Shape(string color)
    {
        this.color = color;
    }

    public string GetColor()
    {
        return color;
    }

    public abstract double GetArea();
}

// Square class
class Square : Shape
{
    private double side;

    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side;
    }
}

// Rectangle class
class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        this.length = length;
        this.width = width;
    }

    public override double GetArea()
    {
        return length * width;
    }
}

// Circle class
class Circle : Shape
{
    private double radius;

    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

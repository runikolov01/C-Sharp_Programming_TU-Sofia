using System;
using System.Drawing;

namespace E01_121220087
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            // Rectangle
            Console.WriteLine("Enter width of rectangle:");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter height of rectangle:");
            double height = Convert.ToDouble(Console.ReadLine());

            Rectangle rectangle = new Rectangle { Width = width, Height = height };

            Console.WriteLine("Rectangle Perimeter: " + rectangle.Perimeter());
            Console.WriteLine("Rectangle Area: " + rectangle.Area());
            Console.WriteLine("---------------------------------");

            // Circle
            Console.WriteLine("Enter radius of circle:");
            double radius = Convert.ToDouble(Console.ReadLine());

            Circle circle = new Circle { Radius = radius };


            Console.WriteLine("Circle Perimeter: " + circle.Perimeter());
            Console.WriteLine("Circle Area: " + circle.Area());
            Console.WriteLine("---------------------------------");

            // Square
            Console.WriteLine("Enter side length of square:");
            double side = Convert.ToDouble(Console.ReadLine());

            Square square = new Square { Side = side };

            Console.WriteLine("Square Perimeter: " + square.Perimeter());
            Console.WriteLine("Square Area: " + square.Area());
            Console.WriteLine("---------------------------------");

            Circle circle1 = new Circle();

            // Setting color
            Console.WriteLine("SET method");
            Console.WriteLine();
            Console.WriteLine("Enter color (1 for Blue, 2 for Red, 3 for Green):");

            int colorValue = Convert.ToInt32(Console.ReadLine());
            circle1.ColorValue = colorValue;
            Console.WriteLine("---------------------------------");

            // Getting color
            Console.WriteLine("GET method");
            Console.WriteLine();
            Console.WriteLine("Color Value: " + circle1.GetColor());
            Console.WriteLine("---------------------------------");


            // Triangle
            Console.WriteLine("Enter side1 length of triangle:");
            double side1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter side2 length of triangle:");
            double side2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter side3 length of triangle:");
            double side3 = Convert.ToDouble(Console.ReadLine());

            // Check if the entered sides form a valid triangle
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                Console.WriteLine("Invalid triangle sides. Please enter positive numbers for all sides.");
            }
            else
            {
                Triangle<double> triangle;
                bool triangleCreated = Triangle<double>.GetInstance(out triangle, side1, side2, side3);
                Console.WriteLine();
                Console.WriteLine("Triangle created successfully: " + triangleCreated);
                Console.WriteLine("---------------------------------");
            }
        }
    }
}

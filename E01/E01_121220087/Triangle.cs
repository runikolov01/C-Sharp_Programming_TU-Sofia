using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_121220087
{
    public class Triangle<T>
    {
        private T side;

        public Triangle(T side)
        {
            this.side = side;
        }

        public static bool GetInstance(out Triangle<T> triangle, T side1, T side2, T side3)
        {
            if (IsValidTriangle(side1, side2, side3))
            {
                triangle = new Triangle<T>(side1);
                return true;
            }
            else
            {
                triangle = default;
                return false;
            }
        }

        private static bool IsValidTriangle(T side1, T side2, T side3)
        {
            if (side1 is float || side1 is double || side1 is decimal)
            {
                // Float or double type
                double a = Convert.ToDouble(side1);
                double b = Convert.ToDouble(side2);
                double c = Convert.ToDouble(side3);
                return (a + b > c && a + c > b && b + c > a);
            }
            else if (side1 is int)
            {
                // Integer type
                int a = Convert.ToInt32(side1);
                int b = Convert.ToInt32(side2);
                int c = Convert.ToInt32(side3);
                return (a + b > c && a + c > b && b + c > a);
            }
            else
            {
                throw new ArgumentException("Unsupported type for side.");
            }
        }
    }
}
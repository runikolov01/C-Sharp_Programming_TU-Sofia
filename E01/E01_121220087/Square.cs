using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_121220087
{
    public class Square : Rectangle
    {

        public double Side { get; set; }

        public override double Perimeter() => 4 * Side;

        public override double Area() => Side * Side;
       
        public static double CalculateArea(double side) => side * side;
    }
}
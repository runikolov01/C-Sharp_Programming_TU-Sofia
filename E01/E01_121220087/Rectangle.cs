using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_121220087
{
    public class Rectangle : Shape, IEllipseCheck
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Perimeter() => 2 * (Width + Height);
        public override double Area() => Width * Height;

        public bool IsEllipse()
        {
            return false;
        }
    }
}
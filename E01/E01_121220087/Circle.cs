using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_121220087
{
    public class Circle : Shape, IEllipseCheck
    {
        public double Radius { get; set; }

        public override double Perimeter() => 2 * Math.PI * Radius;
        public override double Area() => Math.PI * Math.Pow(Radius, 2);

        public bool IsEllipse()
        {
            return false;
        }
    }
}
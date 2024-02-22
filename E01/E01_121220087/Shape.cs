using System;

namespace E01_121220087
{
    public abstract class Shape
    {

        public abstract double Perimeter();
        public abstract double Area();
        
        public class ColorConstants
        {
            public static int Blue = 1;
            public static int Red = 2;
            public static int Green = 3;
        }

        private int color;

        public int ColorValue
        {
            get { return color; }
            set
            {
                switch (value)
                {
                    case 1:
                        // Blue color
                        color = 1;
                        break;
                    case 2:
                        // Red color
                        color = 2;
                        break;
                    case 3:
                        // Green color
                        color = 3;
                        break;
                    default:
                        throw new ArgumentException("Invalid color value");
                }
            }
        }

        public string GetColor()
        {
            if (color == 1)
                return "Blue";
            else if (color == 2)
                return "Red";
            else if (color == 3)
                return "Green";
            else
                throw new ArgumentException("Invalid color value");
        }

    }
}
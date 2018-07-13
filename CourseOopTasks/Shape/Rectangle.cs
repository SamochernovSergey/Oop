using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double SideA
        {
            get;
            set;
        }

        public double SideB
        {
            get;
            set;
        }

        public double GetWidth()
        {
            return SideA;
        }

        public double GetHeight()
        {
            return SideB;
        }

        public double GetArea()
        {
            return SideA * SideB;
        }

        public double GetPerimeter()
        {
            return 2 * (SideA + SideB);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {
        public double SideLength
        {
            get;
            set;
        }

        public double GetWidth()
        {
            return SideLength;
        }
        public double GetHeight()
        {
            return SideLength;
        }
        public double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }
        public double GetPerimeter()
        {
            return 4 * SideLength;
        }
    }
}

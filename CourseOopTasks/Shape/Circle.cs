using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IShape
    {
        public double Radius
        {
            get;
            set;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }
        public double GetHeight()
        {
            return 2 * Radius;
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}

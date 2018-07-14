using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Shape
    {
        public double X1
        {
            get;
            set;
        }

        public double X2
        {
            get;
            set;
        }

        public double X3
        {
            get;
            set;
        }
        public double Y1
        {
            get;
            set;
        }

        public double Y2
        {
            get;
            set;
        }

        public double Y3
        {
            get;
            set;
        }

        public double GetWidth()
        {
            double min = (X1 < X2) ? ((X1 < X3) ? X1 : X3) : ((X2 < X3) ? X2 : X3);
            double max = (X1 > X2) ? ((X1 > X3) ? X1 : X3) : ((X2 > X3) ? X2 : X3);
            return max - min;//Math.Max(X1, X2, X3) - Math.Min(X1, X2, X3);
        }
        public double GetHeight()
        {
            double min = (Y1 < Y2) ? ((Y1 < Y3) ? Y1 : Y3) : ((Y2 < Y3) ? Y2 : Y3);
            double max = (Y1 > Y2) ? ((Y1 > Y3) ? Y1 : Y3) : ((Y2 > Y3) ? Y2 : Y3);
            return max - min;
        }
        public double GetArea()
        {
            return (X1 * (Y2 - Y3) + X2 * (Y3 - Y1) + X3 * (Y1 - Y2)) / 2;
        }
        public double GetPerimeter()
        {
            double ab = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
            double ac = Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));
            double bc = Math.Sqrt(Math.Pow((X3 - X2), 2) + Math.Pow((Y3 - Y2), 2));
            return ab + ac + bc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : IShape
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
            return Math.Max(Math.Max(X1, X2), X3);
        }
        public double GetHeight()
        {
           return Math.Max(Math.Max(Y1, Y2), Y3);
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

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = 
        }
    }
}

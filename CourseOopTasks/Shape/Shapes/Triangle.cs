using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : IShape
    {
        private double X1
        {
            get;
            set;
        }

        private double X2
        {
            get;
            set;
        }

        private double X3
        {
            get;
            set;
        }
        private double Y1
        {
            get;
            set;
        }

        private double Y2
        {
            get;
            set;
        }

        private double Y3
        {
            get;
            set;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.X3 = x3;
            this.Y3 = y3;
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
            return Math.Abs(((X1 - X3) * (Y2 - Y3) - (X2 -X3) * (Y1 - Y3))/ 2);
        }

        private static double GetLength(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public double GetPerimeter()
        {            
            return GetLength(X1,X2,Y1,Y2) + GetLength(X1, X3, Y1, Y3) + GetLength(X2, X3, Y2, Y3);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Triangle p = (Triangle)obj;
            return X1 == p.X1 && Y1 == p.Y1 && X2 == p.X2 && Y2 == p.Y2 && X3 == p.X3 && Y3 == p.Y3;
        }

        public override string ToString()
        {
            return string.Format("Фигура: Треугольник, Высота = {0}, Ширина = {1}, Площадь = {2}, Периметр = {3}, ХэшКод = {4}", GetWidth(), GetHeight(), GetArea(), GetPerimeter(), GetHashCode());            
        }
    }
}
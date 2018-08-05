using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : IShape
    {
        public double x1
        {
            get;
            set;
        }

        public double x2
        {
            get;
            set;
        }

        public double x3
        {
            get;
            set;
        }
        public double y1
        {
            get;
            set;
        }

        public double y2
        {
            get;
            set;
        }

        public double y3
        {
            get;
            set;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3);
        }

        public double GetArea()
        {
            return Math.Abs(((x1 - x3) * (y2 - y3) - (x2 -x3) * (y1 - y3))/ 2);
        }

        public static double GetLength(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public double GetPerimeter()
        {            
            return GetLength(x1,x2,y1,y2) + GetLength(x1, x3, y1, y3) + GetLength(x2, x3, y2, y3);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + y3.GetHashCode();
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
            return x1 == p.x1 && y1 == p.y1 && x2 == p.x2 && y2 == p.y2 && x3 == p.x3 && y3 == p.y3;
        }

        public override string ToString()
        {
            return string.Format("Фигура: Треугольник, Высота = {0}, Ширина = {1}, Площадь = {2}, Периметр = {3}, ХэшКод = {4}", GetWidth(), GetHeight(), GetArea(), GetPerimeter(), GetHashCode());            
        }
    }
}
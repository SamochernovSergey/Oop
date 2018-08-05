using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : IShape
    {
        public double sideLength
        {
            get;
            set;
        }

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return Math.Pow(sideLength, 2);
        }

        public double GetPerimeter()
        {
            return 4 * sideLength;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + sideLength.GetHashCode();
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

            Square p = (Square)obj;
            return sideLength == p.sideLength;
        }

        public override string ToString()
        {
            return string.Format("Фигура: Квадрат, Высота = {0}, Ширина = {1}, Площадь = {2}, Периметр = {3}, ХэшКод = {4}", GetWidth(), GetHeight(), GetArea(), GetPerimeter(), GetHashCode());           
        }
    }
}

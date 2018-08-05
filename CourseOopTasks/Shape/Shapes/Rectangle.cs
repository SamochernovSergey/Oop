using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IShape
    {
        public double sideA
        {
            get;
            set;
        }

        public double sideB
        {
            get;
            set;
        }
        
        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        public double GetWidth()
        {
            return sideA;
        }

        public double GetHeight()
        {
            return sideB;
        }

        public double GetArea()
        {
            return sideA * sideB;
        }

        public double GetPerimeter()
        {
            return 2 * (sideA + sideB);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + sideA.GetHashCode();
            hash = prime * hash + sideB.GetHashCode();
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

            Rectangle p = (Rectangle)obj;
            return sideA == p.sideA && sideB == p.sideB;
        }

        public override string ToString()
        {
            return string.Format("Фигура: Четырёхугольник, Высота = {0}, Ширина = {1}, Площадь = {2}, Периметр = {3}, ХэшКод = {4}", GetWidth(), GetHeight(), GetArea(), GetPerimeter(), GetHashCode());
        }
    }
}

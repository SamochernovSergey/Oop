using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IShape
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
        
        public Rectangle(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
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

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + SideA.GetHashCode();
            hash = prime * hash + SideB.GetHashCode();
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
            return SideA == p.SideA && SideB == p.SideB;
        }

        public override string ToString()
        {
            return string.Format("Фигура: Четырёхугольник, Высота = {0}, Ширина = {1}, Площадь = {2}, Периметр = {3}, ХэшКод = {4}", GetWidth(), GetHeight(), GetArea(), GetPerimeter(), GetHashCode());
        }
    }
}

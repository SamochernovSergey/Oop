using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IShape
    {
        public double radius
        {
            get;
            set;
        }

        public Circle(double radius)
        {
           this.radius = radius;
        }

        public double GetWidth()
        {
            return 2 * radius;
        }

        public double GetHeight()
        {
            return 2 * radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + radius.GetHashCode();            
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

            Circle p = (Circle)obj;
            return radius == p.radius;
        }

        public override string ToString()
        {
            return string.Format("Фигура: Круг, Высота = {0}, Ширина = {1}, Площадь = {2}, Периметр = {3}, ХэшКод = {4}", GetWidth(), GetHeight(), GetArea(), GetPerimeter(), GetHashCode());
        }
    }
}

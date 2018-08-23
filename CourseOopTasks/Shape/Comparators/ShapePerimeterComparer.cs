using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape a, IShape b)
        {
            return a.GetPerimeter().CompareTo(b.GetPerimeter());
        }
    }
}
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
            if (a.GetPerimeter() > b.GetPerimeter())
            {
                return 1;
            }
            else if (a.GetPerimeter() < b.GetPerimeter())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }     
    }
}
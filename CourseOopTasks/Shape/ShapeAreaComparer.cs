using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapeAreaComparer : IComparer<IShape>
    {
          public int Compare(IShape a, IShape b)
        {
            if (a.GetArea() > b.GetArea())
            {
                return 1;
            }
            else if (a.GetArea() < b.GetArea())
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
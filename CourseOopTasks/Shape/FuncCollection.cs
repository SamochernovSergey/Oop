using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class FuncCollection
    {
        public static IShape GetMaxArea(IShape[] shapesArray)
        {
            Array.Sort(shapesArray, new ShapeAreaComparer());
            return shapesArray[shapesArray.Length - 1];
        }

        public static IShape GetSecondMaxPerimeter(IShape[] shapesArray)
        {
            Array.Sort(shapesArray, new ShapePerimeterComparer());
            return shapesArray[shapesArray.Length - 2];
        }
    }
}
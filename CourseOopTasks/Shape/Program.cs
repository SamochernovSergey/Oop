using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle a = new Triangle(1.0, 2.4, 3.1, 4, 5, 6);
            Circle b = new Circle(4.3);
            Rectangle c = new Rectangle(14, 3);
            Triangle d = new Triangle(2.0, 5.2, 4.7, 7, 9, 0);
            Circle e = new Circle(2.9);
            Rectangle f = new Rectangle(20, 21);
            Square g = new Square(33);
            
            IShape[] shapesArray = { a, b, c, d, e, f, g };

            Console.WriteLine(FuncCollection.GetMaxArea(shapesArray));
            Console.WriteLine(FuncCollection.GetSecondMaxPerimeter(shapesArray));
        }
        
    }    
}

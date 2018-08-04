using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        public class ShapesComparer : IComparer<IShape>
        {
            public int Compare(IShape a, IShape b)
            {
                if (consonants.Contains(a) == true &&
                   vovels.Contains(b) == true)
                    return 1;
                if (vovels.Contains(a) == true &&
                  consonants.Contains(b) == true)
                    return -1;
                return a.CompareTo(b);
            }
        }

        static void Main(string[] args)
        {
            Triangle a = new Triangle(1.0, 2.4, 3.1, 4, 5, 6);
            Console.WriteLine(a);

            Circle b = new Circle(9.3);
            Console.WriteLine(b);

            Rectangle c = new Rectangle(14, 3);
            Console.WriteLine(c);


            iShape[] shapesArray = { a, b, c };
            

            
            Array.Sort(shape, new ShapesComparer());

            foreach (Person p in people)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.Age);
            }
        }       
    }    
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 1, 2, 3, 4, 5};
            Vector q = new Vector(9);
            Vector v = new Vector(3, a);
            Vector b = new Vector(a);
            Vector y = new Vector(v);
            Console.WriteLine(y.Equals(q));
            Console.WriteLine("Вектор v = ");
            Console.WriteLine(v);
            Console.WriteLine("Вектор b = ");
            Console.WriteLine(b);
            Vector c = Vector.Addition(v,b);
            Console.WriteLine("Addition(v,b) = ");
            Console.WriteLine(c);
            Console.WriteLine("Вектор v = ");
            Console.WriteLine(v);
            Console.WriteLine("Вектор b = ");
            Console.WriteLine(b);
            Vector d = Vector.Subtraction(q, c);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(q);            
            Console.WriteLine(y);
            Console.WriteLine(b.GetSize());            
            double scalar = Vector.ScalarProduct(v,b);
            Console.WriteLine(scalar);
            Console.WriteLine(v);
            Console.WriteLine(c);
            v.Addition(d);
            Console.WriteLine(v);
            Console.WriteLine(v.GetSize());
            Console.WriteLine(v.GetComponentByIndex(3));
            v.SetComponentByIndex(3,12);
            Console.WriteLine(v);
            v.GetReverse();
            Console.WriteLine(v);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Test
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(7.5, 12.3);
            Range range2 = new Range(2.5, 9.1);
            Range range3 = new Range(1.1, 20.3);

            Console.WriteLine("Длина range1 = {0} Длина range2 = {1}", range1.GetLength(), range2.GetLength());

            double number = 12;
            Console.WriteLine("number = {0} принадлежит range1 {1}", number, range1.IsInside(number));
            Console.WriteLine("number = {0} принадлежит range2 {1}", number, range2.IsInside(number));

            Console.WriteLine("Результат пересечения отрезков {0} и {1} = {2}", range1, range2, range1.GetIntersection(range2));

            Console.WriteLine("Результат обьединения отрезков {0} и {1} : ", range1, range2);
            foreach (Range e in range1.GetAssociation(range2))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range3, range2);
            foreach (Range e in range3.GetDifference(range2))
            {
                Console.WriteLine(e);
            }
       
        }
    }
}
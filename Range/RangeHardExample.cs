using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class RangeHardExample
    {
        static void Main(string[] args)
        {
            RangeHard range1 = new RangeHard(7.5, 12.3);
            RangeHard range2 = new RangeHard(2.5, 9.1);
            RangeHard range3 = new RangeHard(1.1, 20.3);

            Console.WriteLine("Длина range1 = {0} Длина range2 = {1}", range1.GetLength(), range2.GetLength());
            Console.WriteLine("Результат пересечения отрезков {0} и {1} = {2}",range3.Print(), range2.Print(), range3.GetIntersection(range2).Print());

            foreach(RangeHard e in range1.GetAssociation(range2))
            {
                Console.WriteLine("Результат обьединения отрезков {0} и {1} = {2} ",range1.Print(), range2.Print(), e.Print());
            }

            foreach (RangeHard e in range3.GetDifference(range2))
            {
                Console.WriteLine("Результат разности отрезков {0} и {1} = {2}", range3.Print(), range2.Print(), e.Print());
            }
        }
    }
}
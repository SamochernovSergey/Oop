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
            Range range1 = new Range(9.1, 12.3);
            Range range2 = new Range(2.5, 9.1);
            Range range3 = new Range(1.1, 20.3);
            Range range4 = new Range(4.7, 10.2);
            Range range5 = new Range(9.2, 10.2);

            Console.WriteLine("Длина отрезков");
            Console.WriteLine("Длина range1 = {0} Длина range2 = {1}", range1.GetLength(), range2.GetLength());

            Console.WriteLine("Проверка принадлежности");
            double number = 12;
            Console.WriteLine("number = {0} принадлежит range1 {1}", number, range1.IsInside(number));
            Console.WriteLine("number = {0} принадлежит range2 {1}", number, range2.IsInside(number));

            Console.WriteLine("Пересечение");
            Console.WriteLine("Результат пересечения отрезков {0} и {1} = {2}", range1, range5, range1.GetIntersection(range5));
            Console.WriteLine("Результат пересечения отрезков {0} и {1} = {2}", range4, range3, range4.GetIntersection(range3));
            Console.WriteLine("Результат пересечения отрезков {0} и {1} = {2}", range1, range2, range1.GetIntersection(range2));

            Console.WriteLine("Обьединение");
            Console.WriteLine("Результат обьединения отрезков {0} и {1} : ", range1, range2);
            foreach (Range e in range1.GetAssociation(range2))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Результат обьединения отрезков {0} и {1} : ", range2, range5);
            foreach (Range e in range2.GetAssociation(range5))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Разность");
            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range2, range1);
            foreach (Range e in range2.GetDifference(range1))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range2, range4);
            foreach (Range e in range2.GetDifference(range4))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range1, range4);
            foreach (Range e in range1.GetDifference(range4))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range3, range4);
            foreach (Range e in range3.GetDifference(range4))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range2, range2);
            foreach (Range e in range2.GetDifference(range2))
            {
                Console.WriteLine(e);
            }
            
            Console.ReadLine();
        }
    }
}
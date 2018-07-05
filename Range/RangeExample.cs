using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class RangeExample
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(7.5, 12.3);
            Range range2 = new Range(2.5, 11.1);
            Console.WriteLine("Длина range1 = {0} Длина range2 = {1}", range1.GetLengthRange(), range2.GetLengthRange());
            double number = 12;
            Console.WriteLine("number = {0} принадлежит range1 {1}", number, range1.IsInside(number));
            Console.WriteLine("number = {0} принадлежит range2 {1}", number, range2.IsInside(number));
        }   
    }
}
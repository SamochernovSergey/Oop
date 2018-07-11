using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
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

            Console.WriteLine("Результат пересечения отрезков {0} и {1} = {2}", range1.Print(), range2.Print(), range1.GetIntersection(range2).Print());

            Console.WriteLine("Результат обьединения отрезков {0} и {1} : ", range1.Print(), range2.Print());
            foreach (Range e in range1.GetAssociation(range2))
            {
                Console.WriteLine(e.Print());
            }

            Console.WriteLine("Результат разности отрезков {0} и {1} : ", range3.Print(), range2.Print());
            foreach (Range e in range3.GetDifference(range2))
            {
                Console.WriteLine(e.Print());
            }
        }

        private double From
        {
            get;
            set;
        }

        private double To
        {
            get;
            set;
        }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public bool IsInside(double number)
        {
            return number <= To && number >= From;
        }

        public double GetLength()
        {
            return To - From;
        }

        public string Print()
        {
            return '(' + Convert.ToString(From) + ' ' + Convert.ToString(To) + ')';
        }

        public Range GetIntersection(Range range)
        {
            if (From > To)
            {
                double temp = From;
                From = To;
                To = temp;
            }
            if (range.From > range.To)
            {
                double temp = range.From;
                range.From = range.To;
                range.To = temp;
            }
            if (From > range.From)
            {
                double temp = From;
                From = range.From;
                range.From = temp;
                temp = To;
                To = range.To;
                range.To = temp;
            }

            double begin = 0;
            double end = 0;

            if (range.From >= From && To >= range.To)
            {
                begin = range.From;
                end = range.To;
            }
            else if (range.From < To && To < range.To)
            {
                begin = range.From;
                end = To;
            }
            else
            {
                return null;
            }

            Range rangeIntersection = new Range(begin, end);
            return rangeIntersection;
        }

        public Range[] GetAssociation(Range range)
        {
            if (From > To)
            {
                double temp = From;
                From = To;
                To = temp;
            }
            if (range.From > range.To)
            {
                double temp = range.From;
                range.From = range.To;
                range.To = temp;
            }
            if (From > range.From)
            {
                double temp = From;
                From = range.From;
                range.From = temp;
                temp = To;
                To = range.To;
                range.To = temp;
            }

            double begin = 0;
            double end = 0;
            double begin2 = 0;
            double end2 = 0;

            if (range.From >= From && To >= range.To)
            {
                begin = From;
                end = To;
                return new Range[] { new Range(begin, end) };
            }
            else if (range.From < To && To < range.To)
            {
                begin = From;
                end = range.To;                
                return new Range[] { new Range(begin, end) };
            }
            else
            {
                begin = From;
                end = To;
                begin2 = range.From;
                end2 = range.To;                
                return new Range[] { new Range(begin, end), new Range(begin2, end2) };
            }
        }

        public Range[] GetDifference(Range range)
        {
            if (From > To)
            {
                double temp = From;
                From = To;
                To = temp;
            }
            if (range.From > range.To)
            {
                double temp = range.From;
                range.From = range.To;
                range.To = temp;
            }

            double begin = 0;
            double end = 0;
            double begin2 = 0;
            double end2 = 0;

            if (To < range.From || range.To < From)
            {
                begin = From;
                end = To;
                return new Range[] { new Range(begin, end) };
            }
            else if (range.From > From && range.From < To)
            {
                if (range.To >= To)
                {
                    begin = From;
                    end = range.From;
                    return new Range[] { new Range(begin, end) };
                }
                else
                {
                    begin = From;
                    end = range.From;
                    begin2 = range.To;
                    end2 = To;                    
                    return new Range[] { new Range(begin, end), new Range(begin2, end2) };
                }
            }
            else if (From == range.From && To == range.To)
            {
                return null;
            }
            else
            {
                if (To > range.To)
                {
                    begin = range.To;
                    end = To;                    
                    return new Range[] { new Range(begin, end) };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
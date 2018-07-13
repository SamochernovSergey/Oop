using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
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

        public override string ToString()
        {
            return '(' + Convert.ToString(From) + ' ' + Convert.ToString(To) + ')';
        }

        public Range GetIntersection(Range range)
        {
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

            if (To <= range.From)
            {
                return null;
            }
            else if (To < range.To)
            {
                begin = range.From;
                end = To;
            }
            else
            {
                begin = range.From;
                end = range.To;
            }

            Range rangeIntersection = new Range(begin, end);
            return rangeIntersection;
        }

        public Range[] GetAssociation(Range range)
        {
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

            if (To >= range.From)
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
            double begin = 0;
            double end = 0;
            double begin2 = 0;
            double end2 = 0;

                 if (From >= range.To || To <= range.From)
            {
                begin = From;
                end = To;
                return new Range[] { new Range(begin, end) };
            }
            else if (From >= range.From && To <= range.To)
            {
                return new Range[] { };
            }            
            else if (From < range.From && To <= range.To)
            {
                begin = From;
                end = range.From;
                return new Range[] { new Range(begin, end) };
            }
            else if (From >= range.From && To > range.To)
            {
                begin = range.To;
                end = To;
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
    }
}
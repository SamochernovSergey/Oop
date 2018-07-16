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
            return ("(" + From + " " + To + ")");
        }

        public Range GetIntersection(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return null;
            }
            else
            {
                return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
            }
        }

        public Range[] GetAssociation(Range range)
        {
            if (To < range.From || From > range.To)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
                
            }
            else
            {
                return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
            }
        }

        public Range[] GetDifference(Range range)
        {
            if (From >= range.To || To <= range.From)
            {
                return new Range[] { new Range(From, To) };
            }
            else if (From < range.From && To > range.To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            else if (From < range.From)
            {
                return new Range[] { new Range(From, range.From) };
            }
            else if (To > range.To)
            {
                return new Range[] { new Range(range.To, To) };
            }
            else
            {
                return new Range[] { };
            }
        }
    }
}
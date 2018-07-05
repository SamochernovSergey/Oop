using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class RangeHard
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

        public RangeHard(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public double GetLength()
        {
            return To - From;
        }
        public string Print()
        {
            return '(' + Convert.ToString(From) + ' ' + Convert.ToString(To) + ')';
        }


        public RangeHard GetIntersection(RangeHard range)
        {
            double begin;
            double end;            

            if ( From > range.To || To < range.From)
            {
                return null;
            }
            else if (From < range.From &  To > range.From)
            {
                if (range.To >= To)
                {
                    begin = range.From;
                    end = To;
                }
                else
                {
                    begin = range.From;
                    end = range.To;
                }
            }
            else if (From == range.From & To == range.To)
            {
                begin = From;
                end = To;
            }
            else
            {
                if (To >= range.To)
                {
                    begin = From;
                    end = range.To;
                }
                else
                {
                    begin = From;
                    end = To;
                }
            }
            RangeHard rangeIntersection = new RangeHard(begin, end);
            return rangeIntersection;
        }

        public RangeHard[] GetAssociation(RangeHard range)
        {
            RangeHard[] arrayRangeAssociation = new RangeHard[1];
            double begin = 0;
            double end = 0;
            double begin2 = 0;
            double end2 = 0;

            if (To < range.From || range.To < From)
            {
                begin = From;
                end = To;
                begin2 = range.From;
                end2 = range.To;
                Array.Resize<RangeHard>(ref arrayRangeAssociation, 2);
                RangeHard rangeAssociation2 = new RangeHard(begin2, end2);                
            }
            else if (range.From > From & range.From < To)
            {
                if (range.To >= To)
                {
                    begin = From;
                    end = range.To;
                }
                else
                {
                    begin = From;
                    end = To;
                }
            }
            else if (From == range.From & To == range.To)
            {
                begin = From;
                end = To;
            }
            else
            {
                if (To >= range.To)
                {
                    begin = range.From;
                    end = To;
                }
                else
                {
                    begin = range.From;
                    end = range.To;
                }
            }
            RangeHard rangeAssociation = new RangeHard(begin, end);
            arrayRangeAssociation[0] = rangeAssociation;
            return arrayRangeAssociation;
        }

        public RangeHard[] GetDifference(RangeHard range)
        {
            RangeHard[] arrayRangeDifference = new RangeHard[1];
            double begin = 0;
            double end = 0;
            double begin2 = 0;
            double end2 = 0;             

            if (To < range.From || range.To < From)
            {
                begin = From;
                end = To;               
            }
            else if (range.From > From & range.From < To)
            {
                if (range.To >= To)
                {
                    begin = From;
                    end = range.From;
                }
                else
                {
                    begin = From;
                    end = range.From;
                    begin2 = range.To;
                    end2 = To;
                    Array.Resize<RangeHard>(ref arrayRangeDifference, 2);
                    RangeHard rangeDifference2 = new RangeHard(begin2, end2);
                    arrayRangeDifference[1] = rangeDifference2;
                }
            }
            else if (From == range.From & To == range.To)
            {
                return null;
            }
            else
            {
                if (To > range.To)
                {
                    begin = range.To;
                    end = To;
                }
                else
                {
                    return null;
                }
            }
            RangeHard rangeDifference = new RangeHard(begin, end);            
            arrayRangeDifference[0] = rangeDifference;            
            return arrayRangeDifference;
        }
    }
}
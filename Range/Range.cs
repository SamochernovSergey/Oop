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

        public double GetLengthRange()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number <= To && number >= From;
        }
    }
}
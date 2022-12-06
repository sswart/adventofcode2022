using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.Day4
{
    internal class Day4
    {
        internal static int GetFullyContainedPairs(string[] lines)
        {
            int sum = 0;
            foreach(var line in lines)
            {
                var pair = line.Split(',');

                var interval1 = GetInterval(pair[0]);
                var interval2 = GetInterval(pair[1]);

                if (interval1.IsWithin(interval2) || interval2.IsWithin(interval1))
                {
                    sum++;
                }
            }
            return sum;
        }

        internal static int GetOverlap(string[] lines)
        {
            int sum = 0;
            foreach (var line in lines)
            {
                var pair = line.Split(',');

                var interval1 = GetInterval(pair[0]);
                var interval2 = GetInterval(pair[1]);

                if (interval1.HasOverlap(interval2) || interval2.HasOverlap(interval1))
                {
                    sum++;
                }
            }
            return sum;
        }

        private static Interval GetInterval(string v)
        {
            var split = v.Split('-');
            return new Interval(int.Parse(split[0]), int.Parse(split[1]));
        }

        private class Interval
        {

            public int Start { get; }
            public int End { get; }

            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }

            public bool IsWithin(Interval interval)
            {
                return Start <= interval.Start && interval.End <= End;
            }

            public bool HasOverlap(Interval interval)
            {
                return IsWithin(interval.Start) || IsWithin(interval.End);
            }

            private bool IsWithin(int point)
            {
                return point >= Start && point <= End;
            }
        }
    }
}

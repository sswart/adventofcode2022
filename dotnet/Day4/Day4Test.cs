using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotnet.Day4
{
    public class Day4Test
    {
        [Fact]
        public void Sample_HasTwoPairs()
        {
            var lines = File.ReadAllLines("Day4Sample1.txt");
            int result = Day4.GetFullyContainedPairs(lines);
            result.Should().Be(2);
        }

        [Fact]
        public void Sample_HasFourOVerlap()
        {
            var lines = File.ReadAllLines("Day4Sample1.txt");
            int result = Day4.GetOverlap(lines);
            result.Should().Be(4);
        }
    }
}

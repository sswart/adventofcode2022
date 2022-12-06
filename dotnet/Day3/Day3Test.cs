using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotnet.Day3
{
    public class Day3Test
    {
        [Fact]
        public void Sum_Priorities_157()
        {
            var lines = File.ReadAllLines("sample.txt");

            int result = Day3.CalculateSumOfPriorities(lines);
            result.Should().Be(157);
        }

        [Fact]
        public void FirstLine_16()
        {
            var lines = File.ReadAllLines("sample.txt");

            Day3.GetCommonCharacter(lines[0]).Should().Be('p');
            Day3.GetScore('p').Should().Be(16);
        }

        [Fact]
        public void SecondLine_38()
        {
            var lines = File.ReadAllLines("sample.txt");
            Day3.GetCommonCharacter(lines[1]).Should().Be('L');
            Day3.GetScore('L').Should().Be(38);
        }
    }
}

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static dotnet.Day2;

namespace dotnet
{
    public class TestDay2
    {
        [Fact]
        public void SampleFile_Gives_15()
        {
            var lines = File.ReadAllLines("day2sample.txt");

            Day2.GetScore(lines).Should().Be(15);
        }

        [Fact]
        public void Rock_Paper_Gives_8()
        {
            var rock = new Rock();
            var paper = new Paper();

            paper.Outcome(rock).Should().Be(8);
        }
    }
}

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotnet.Day7
{
    public class InputParserTest
    {
        [Fact]
        public void Test()
        {
            var lines = System.IO.File.ReadAllLines("./Day7/Day7Sample.txt");

            var result = InputParser.Parse(lines);

            result.Children.Count().Should().Be(4);
            var dirA = result.GetOrCreateChildDirectory("a");
            dirA.Children.Count().Should().Be(4);

            dirA.GetSize().Should().Be(94853);
        }
    }
}

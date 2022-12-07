using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotnet.Day7
{
    public class Day7Test
    {
        [Fact]
        public void Test()
        {
            var lines = System.IO.File.ReadAllLines("./Day7/Day7Sample.txt");
            Day7.GetEligibleTotalSize(lines).Should().Be(95437);
        }

        [Fact]
        public void TestToDelete()
        {
            var lines = System.IO.File.ReadAllLines("./Day7/Day7Sample.txt");
            var toDelete = Day7.GetDirectoryToDelete(lines);
            toDelete.Name.Should().Be("d");
        }
    }
}

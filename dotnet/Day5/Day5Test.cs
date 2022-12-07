using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotnet.Day5
{
    public class Day5Test
    {
        [Fact]
        public void Parse_Stacks()
        {
            var lines = File.ReadAllLines("Day5Sample.txt");

            var stacks = Day5.GetStacks(lines);

            stacks.Count().Should().Be(3);
            stacks[0].Count().Should().Be(2);
        }

        [Fact]
        public void Parse_Instructions()
        {
            var lines = File.ReadAllLines("Day5Sample.txt");
            var instructions = Day5.GetInstructions(lines);
            
            instructions.Count().Should().Be(4);
            instructions[1].Should().BeEquivalentTo(new Instruction(3, 1, 3));
        }

        [Fact]
        public void Transform()
        {
            var lines = File.ReadAllLines("Day5Sample.txt");
            var stacks = Day5.GetStacks(lines);
            var instructions = Day5.GetInstructions(lines);

            Day5.Transform(stacks, instructions);

            stacks[0].Pop().Should().Be('C');
            stacks[1].Pop().Should().Be('M');
            stacks[2].Pop().Should().Be('Z');
        }

        [Fact]
        public void Transform_9001()
        {
            var lines = File.ReadAllLines("Day5Sample.txt");
            var stacks = Day5.GetStacks(lines);
            var instructions = Day5.GetInstructions(lines);

            Day5.Transform9001(stacks, instructions);

            stacks[0].Pop().Should().Be('M');
            stacks[1].Pop().Should().Be('C');
            stacks[2].Pop().Should().Be('D');
        }
    }
}

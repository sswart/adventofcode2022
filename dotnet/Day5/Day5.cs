using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.Day5
{
    internal class Day5
    {
        public static void Transform9001(Stack<char>[] stacks, Instruction[] instructions)
        {
            foreach(var instruction in instructions)
            {
                var toMove = PopMultiple(stacks[instruction.From - 1], instruction.Quantity).Reverse().ToArray();
                foreach(var item in toMove)
                {
                    stacks[instruction.To - 1].Push(item);
                }
            }
        }

        private static IEnumerable<T> PopMultiple<T>(Stack<T> stack, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return stack.Pop();
            }
        }

        public static void Transform(Stack<char>[] stacks, Instruction[] instructions)
        {
            foreach(var instruction in instructions)
            {
                for (int i = 0; i < instruction.Quantity; i++)
                {
                    var source = stacks[instruction.From - 1].Pop();
                    stacks[instruction.To - 1].Push(source);
                }
            }
        }

        public static Instruction[] GetInstructions(string[] lines)
        { 
            var splitInstructions = lines.Where(l => l.StartsWith("move")).Select(l => l.Split(" "));
            var rv = new List<Instruction>();
            foreach(var split in splitInstructions)
            {
                var quantity = int.Parse(split[1]);
                var from = int.Parse(split[3]);
                var to = int.Parse(split[5]);
                rv.Add(new Instruction(quantity, from, to));
            }
            return rv.ToArray();
        }

        private static readonly Func<string, bool> HasStackExpression = line => line.Contains('[');
        public static Stack<char>[] GetStacks(string[] lines)
        {
            var stacks = InitializeStacks(lines);
            FillStacks(lines, stacks);
            return stacks;
        }

        private static void FillStacks(string[] lines, Stack<char>[] stacks)
        {
            var linesWithStacks = lines.TakeWhile(HasStackExpression);
            foreach (var line in linesWithStacks.Reverse())
            {
                for (int i = 0; i < stacks.Length; i++)
                {
                    int startIndex = 1;
                    int characterIndex = startIndex + (i * 4);
                    if (TryGetLetter(line, characterIndex, out var character))
                    {
                        stacks[i].Push(character);
                    }
                }
            }
        }

        private static Stack<char>[] InitializeStacks(string[] lines)
        {
            var numberLine = lines.SkipWhile(HasStackExpression).First();
            var highestNumber = numberLine.Where(char.IsNumber).Max();
            var numberOfStacks = int.Parse(highestNumber.ToString());
            var stacks = new List<Stack<char>>();
            for (int i = 0; i < numberOfStacks; i++)
            {
                stacks.Add(new Stack<char>());
            }
            return stacks.ToArray();
        }

        private static bool TryGetLetter(string line, int index, out char output)
        {
            if (line.Length >= index && char.IsLetter(line[index]))
            {
                output = line[index];
                return true;
            }
            output = default;
            return false;
        }
    }

    public record Instruction(int Quantity, int From, int To);
}

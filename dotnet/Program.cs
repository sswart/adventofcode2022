using dotnet.Day2;
using dotnet.Day3;
using dotnet.Day4;
using dotnet.Day5;
using System.Text;

var lines = File.ReadAllLines("Day5Input.txt");

var stacks = Day5.GetStacks(lines);
var instructions = Day5.GetInstructions(lines);
Day5.Transform(stacks, instructions);

Console.WriteLine(stacks.Select(s => s.Pop()).ToArray());
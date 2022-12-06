using dotnet.Day2;
using dotnet.Day3;

var lines = await File.ReadAllLinesAsync("day3input.txt");


var score = Day3.CalculateSumOfPriorities(lines);

Console.WriteLine($"{score}");

Console.WriteLine($"Badges: {Day3.GetBadgePriorities(lines)}");
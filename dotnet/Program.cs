using dotnet.Day2;
using dotnet.Day3;
using dotnet.Day4;

var lines = await File.ReadAllLinesAsync("Day4Input1.txt");
Console.WriteLine(Day4.GetFullyContainedPairs(lines));


Console.WriteLine(Day4.GetOverlap(lines));
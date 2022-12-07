using dotnet.Day2;
using dotnet.Day3;
using dotnet.Day4;
using dotnet.Day5;
using dotnet.Day6;
using dotnet.Day7;
using System.Text;
using Dir = dotnet.Day7.Directory;

var lines = System.IO.File.ReadAllLines("./Day7/Day7Input.txt");
Console.WriteLine(Day7.GetEligibleTotalSize(lines));

var toDelete = Day7.GetDirectoryToDelete(lines);
Console.WriteLine(toDelete.GetSize());

using dotnet;

var lines = await File.ReadAllLinesAsync("input.txt");
Day2.GetScore( lines);

var predictedScore = Day2.PredictMove(lines);
Console.WriteLine($"Predicted score: {predictedScore}");
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.Day7
{
    internal class InputParser
    {
        public static Directory Parse(string[] lines)
        {
            var root = new Directory("/", null);
            var currentDirectory = root;

            var enumerator = ((IEnumerable<string>)lines).GetEnumerator();
            enumerator.MoveNext();

            while (enumerator.MoveNext()) 
            {
                var current = enumerator.Current;
                if (current == "$ ls")
                {
                    var lsLines = GetLsLines(enumerator).ToArray();
                    var children = ParseLsLines(lsLines, currentDirectory);
                    currentDirectory.Add(children);

                    try
                    {
                        current = enumerator.Current;
                    }
                    catch (InvalidOperationException)
                    {
                        break;
                    }
                }

                if (current.StartsWith("$ cd"))
                {
                    var newDirectoryName = current.Split(" ")[2];
                    if (newDirectoryName == "..")
                    {
                        if (currentDirectory.Parent != null)
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                        else
                        {
                            throw new InvalidOperationException("Traverse up attempted but directory has not parent");
                        }
                    }
                    else if (newDirectoryName == "/")
                    {
                        currentDirectory = root;
                    }
                    else
                    {
                        currentDirectory = currentDirectory.GetOrCreateChildDirectory(newDirectoryName);
                    }
                }
            }
            return root;
        }

        private static IEnumerable<ISize> ParseLsLines(IEnumerable<string> lines, Directory currentDirectory)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("dir"))
                {
                    yield return new Directory(line.Split(" ")[1], currentDirectory);
                }
                else
                {
                    var split = line.Split(" ");
                    yield return new File(split[1], int.Parse(split[0]));
                }
            }
        }

        private static IEnumerable<string> GetLsLines(IEnumerator<string> enumerator)
        {
            if (enumerator.Current != "$ ls")
            {
                throw new ArgumentException("Invalid start position");
            }
            enumerator.MoveNext();
            while (!enumerator.Current.StartsWith("$"))
            {
                yield return enumerator.Current;
                if (!enumerator.MoveNext())
                {
                    yield break;
                }
            }
        }
    }
}

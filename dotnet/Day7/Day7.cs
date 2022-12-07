using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.Day7
{
    internal class Day7
    {
        public static int GetEligibleTotalSize(string[] lines)
        {
            var fs = InputParser.Parse(lines);

            // get all directories
            List<Directory> allDirectories = GetAllDirectories(fs);

            return allDirectories.Select(dir => dir.GetSize()).Where(size => size <= 100000).Sum();
        }

        private static List<Directory> GetAllDirectories(Directory fs)
        {
            var allDirectories = new List<Directory>();
            allDirectories.Add(fs);
            AddSubDirectories(allDirectories, fs);
            return allDirectories;
        }

        static void AddSubDirectories(List<Directory> result, Directory source)
        {
            foreach (var dir in source.SubDirectories)
            {
                result.Add(dir);
                AddSubDirectories(result, dir);
            }
        }

        public static Directory GetDirectoryToDelete(string[] lines)
        {
            int totalSpace = 70000000;
            int requiredFree = 30000000;

            var fs = InputParser.Parse(lines);

            var currentFree = totalSpace - fs.GetSize();
            var minimalDirectorySize = requiredFree - currentFree;

            var all = GetAllDirectories(fs);
            return all.Where(dir => dir.GetSize() >= minimalDirectorySize).MinBy(d => d.GetSize());
        }
    }
}

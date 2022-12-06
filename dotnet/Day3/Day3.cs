using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.Day3
{
    internal class Day3
    {
        public static int CalculateSumOfPriorities(string[] lines)
        {
            int sum = 0;
            foreach(var line in lines)
            {
                sum += GetScore(GetCommonCharacter(line));
            }
            return sum;
        }

        public static char GetCommonCharacter(string line)
        {
            var firstHalf = line.Take(line.Length / 2);
            var secondHalf = line.Skip(line.Length / 2);

            var common = firstHalf.Join(secondHalf, outer => outer, inner => inner, (c, inner) => inner);

            if (!common.Any())
            {
                common = secondHalf.Join(firstHalf, outer => outer, inner => inner, (c, inner) => inner);
            }
            return common.Distinct().Single();
        }

        public static int GetScore(char character)
        {
            if (char.IsUpper(character))
            {
                return (character % 32) + 26;
            }
            return character % 32;
        }

        public static int GetBadgePriorities(string[] lines)
        {
            int count = 0;
            int sum = 0;
            while (true)
            {
                if (count == lines.Length)
                {
                    break;
                }

                var set = lines.Skip(count).Take(3).ToArray();
                var commonChar = GetCommonChar(set);
                sum += GetScore(commonChar);
                count += 3;
            }
            return sum;
        }

        public static char GetCommonChar(string[] lines)
        {
            var joined = lines[0].Join(lines[1], inner => inner, outer => outer, (c, inner) => inner).Join(lines[2], inner => inner, outer => outer, (c, inner) => inner);
            return joined.Distinct().Single();
        }
    }
}

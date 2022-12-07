using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.Day6
{
    internal static class PacketFinder
    {
        public static int FindPacketStart(string input)
        {
            return FindMarker(input, 4);
        }

        public static int FindMessageStart(string input)
        {
            return FindMarker(input, 14);
        }
        private static int FindMarker(string input, int markerLength)
        {
            for (int i = 0; i < input.Length - markerLength; i++)
            {
                var potentialPacket = input.Substring(i, markerLength);
                if (potentialPacket.Distinct().Count() == markerLength)
                {
                    return i + markerLength;
                }
            }
            throw new ArgumentException("Input does not contain packet");
        }
    }
}

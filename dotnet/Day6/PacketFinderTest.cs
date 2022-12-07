using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace dotnet.Day6
{
    public class PacketFinderTest
    {
        [Fact]
        public void TestPacketStart()
        {
            PacketFinder.FindPacketStart("mjqjpqmgbljsphdztnvjfqwrcgsmlb").Should().Be(7);
            PacketFinder.FindPacketStart("bvwbjplbgvbhsrlpgdmjqwftvncz").Should().Be(5);
            PacketFinder.FindPacketStart("nppdvjthqldpwncqszvftbrmjlhg").Should().Be(6);
            PacketFinder.FindPacketStart("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg").Should().Be(10);
            PacketFinder.FindPacketStart("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw").Should().Be(11);
        }

        [Fact]
        public void TestMessageStart()
        {
            PacketFinder.FindMessageStart("mjqjpqmgbljsphdztnvjfqwrcgsmlb").Should().Be(19);
            PacketFinder.FindMessageStart("bvwbjplbgvbhsrlpgdmjqwftvncz").Should().Be(23);
            PacketFinder.FindMessageStart("nppdvjthqldpwncqszvftbrmjlhg").Should().Be(23);
            PacketFinder.FindMessageStart("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg").Should().Be(29);
            PacketFinder.FindMessageStart("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw").Should().Be(26);
        }
    }
}

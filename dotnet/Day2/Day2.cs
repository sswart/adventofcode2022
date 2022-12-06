using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace dotnet.Day2
{
    internal class Day2Impl
    {
        public static int PredictMove(string[] lines)
        {
            int score = 0;
            foreach (var line in lines)
            {
                var chars = line.Split(' ').Select(c => c.First()).ToArray();
                if (chars.Length != 2)
                {
                    throw new ArgumentException($"Invalid data on line: {line}");
                }

                var p1 = ParseMove(chars[0]);
                var expectedOutcome = GetDesiredOutcome(chars[1]);

                switch (expectedOutcome)
                {
                    case Outcome.Draw:
                        score += p1.Outcome(p1);
                        break;
                    case Outcome.Win:
                        score += AllMoves.First(m => m.WinsFrom(p1)).Outcome(p1);
                        break;
                    case Outcome.Lose:
                        score += AllMoves.First(m => !m.WinsFrom(p1) && m.Score != p1.Score).Outcome(p1);
                        break;
                    default:
                        throw new NotImplementedException();

                }
            }
            return score;
        }

        private static readonly Move[] AllMoves = new Move[]
        {
            new Rock(),
            new Paper(),
            new Scissors()
        };

        private static Outcome GetDesiredOutcome(char character)
        {
            return character == 'X' ? Outcome.Lose : character == 'Y' ? Outcome.Draw : character == 'Z' ? Outcome.Win : throw new ArgumentException("invalid input");
        }


        public static int GetScore(string[] lines)
        {
            int score = 0;
            foreach (var line in lines)
            {
                var chars = line.Split(' ').Select(c => c.First()).ToArray();
                if (chars.Length != 2)
                {
                    throw new ArgumentException($"Invalid data on line: {line}");
                }

                var p1 = ParseMove(chars[1]);
                var p2 = ParseMove(chars[0]);

                score += p1.Outcome(p2);
            }

            Console.WriteLine($"Total score: {score}");
            return score;
        }

        static Move ParseMove(char identifier)
        {
            if (identifier == 'X' || identifier == 'A')
            {
                return new Rock();
            }
            else if (identifier == 'Y' || identifier == 'B')
            {
                return new Paper();
            }
            else if (identifier == 'Z' || identifier == 'C')
            {
                return new Scissors();
            }
            throw new ArgumentException("Not a valid input");
        }

        public interface Move
        {
            int Score { get; }
            int Outcome(Move other);
            bool WinsFrom(Move other);

        }
        public class Rock : Move
        {
            public int Score => 1;

            public int Outcome(Move other)
            {
                if (other is Rock)
                {
                    return Score + 3;
                }
                else if (other is Paper)
                {
                    return Score;
                }
                return Score + 6;
            }

            public bool WinsFrom(Move other) => other is Scissors;
        }

        public class Paper : Move
        {
            public int Score => 2;

            public int Outcome(Move other)
            {
                if (other is Paper)
                {
                    return Score + 3;
                }
                else if (other is Scissors)
                {
                    return Score;
                }
                return Score + 6;
            }

            public bool WinsFrom(Move other) => other is Rock;
        }

        public class Scissors : Move
        {
            public int Score => 3;

            public int Outcome(Move other)
            {
                if (other is Scissors)
                {
                    return Score + 3;
                }
                else if (other is Rock)
                {
                    return Score;
                }
                return Score + 6;
            }

            public bool WinsFrom(Move other) => other is Paper;
        }

        public enum Outcome
        {
            Win,
            Lose,
            Draw
        }
    }
}

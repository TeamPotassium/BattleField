namespace BattleField
{
    using System;
    using System.Text.RegularExpressions;

    public struct Coordinates
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        private static readonly Coordinates minValue = new Coordinates(int.MinValue, int.MinValue);
        public static Coordinates MinValue { get { return Coordinates.minValue; } }

        private static readonly Coordinates maxValue = new Coordinates(int.MaxValue, int.MaxValue);
        public static Coordinates MaxValue { get { return Coordinates.maxValue; } }

        public Coordinates(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b)
        {
            Coordinates result = checked(new Coordinates(a.Row + b.Row, a.Col + b.Col));
            return result;
        }

        public static Coordinates operator -(Coordinates a, Coordinates b)
        {
            Coordinates result = checked(new Coordinates(a.Row - b.Row, a.Col - b.Col));
            return result;
        }

        public static Coordinates Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "Value can not be null.");
            }

            Match match = Regex.Match(input, @"^\s*(\d+)\s+(\d+)\s*$");

            if (!match.Success)
            {
                throw new FormatException("Input string was not in a correct format.");
            }

            int row = int.Parse(match.Groups[1].Value);
            int col = int.Parse(match.Groups[2].Value);

            Coordinates result = new Coordinates(row, col);
            return result;
        }

        public static bool TryParse(string input, out Coordinates result)
        {
            try
            {
                result = Coordinates.Parse(input);
                return true;
            }
            catch
            {
                result = new Coordinates(0, 0);
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Row, this.Col);
        }
    }
}

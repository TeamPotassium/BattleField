namespace BattleField
{
    using System;

    public struct Coordinates
    {
        public Coordinates(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        private static readonly Coordinates minValue = new Coordinates(int.MinValue, int.MinValue);
        public static Coordinates MinValue { get { return Coordinates.minValue; } }

        private static readonly Coordinates maxValue = new Coordinates(int.MaxValue, int.MaxValue);
        public static Coordinates MaxValue { get { return Coordinates.maxValue; } }

        public static Coordinates operator +(Coordinates a, Coordinates b)
        {
            return new Coordinates(a.Row + b.Row, a.Col + b.Col);
        }

        public static Coordinates operator -(Coordinates a, Coordinates b)
        {
            return new Coordinates(a.Row - b.Row, a.Col - b.Col);
        }

        public override string ToString()
        {
            return string.Format("Coordinates({0}, {1})", this.Row, this.Col);
        }
    }
}
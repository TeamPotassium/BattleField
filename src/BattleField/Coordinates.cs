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
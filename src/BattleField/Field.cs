namespace BattleField
{
    using System;

    public class Field
    {
        public const string Empty = "-";
        public const string Detonated = "X";

        public const int MaxSize = 9;

        private readonly string[,] field = null;

        private int rows = 0;
        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (!(0 < value && value <= MaxSize))
                {
                    throw new ArgumentOutOfRangeException("rows");
                }

                this.rows = value;
            }
        }

        private int cols = 0;
        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (!(0 < value && value <= MaxSize))
                {
                    throw new ArgumentOutOfRangeException("cols");
                }

                this.cols = value;
            }
        }

        public Field(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;

            this.field = new string[this.Rows, this.Cols];
            this.ForEach(position => this.field[position.Row, position.Col] = Field.Empty);
        }

        public void Destroy(Coordinates coordinates)
        {
            this[coordinates] = Field.Detonated;
        }

        public bool IsMine(Coordinates coordinates)
        {
            bool result = true;

            result = result && this[coordinates] != Field.Empty;
            result = result && this[coordinates] != Field.Detonated;

            return result;
        }

        public Mine GetMine(Coordinates position)
        {
            if (!IsMine(position))
            {
                throw new ArgumentException("There is no mine at this position.");
            }

            Mine mine = (Mine)int.Parse(this[position]);
            return mine;
        }

        public void ForEach(Action<Coordinates> action)
        {
            ForEach(Coordinates.MinValue, Coordinates.MaxValue, action);
        }

        public void ForEach(Coordinates topLeft, Coordinates bottomRight, Action<Coordinates> action)
        {
            Coordinates innerTopLeft = new Coordinates(
                Math.Max(topLeft.Row, 0),
                Math.Max(topLeft.Col, 0));

            Coordinates innerBottomRight = new Coordinates(
                Math.Min(bottomRight.Row, this.Rows - 1),
                Math.Min(bottomRight.Col, this.Cols - 1));

            for (int row = innerTopLeft.Row; row <= innerBottomRight.Row; row++)
            {
                for (int col = innerTopLeft.Col; col <= innerBottomRight.Col; col++)
                {
                    action(new Coordinates(row, col));
                }
            }
        }

        public string this[int row, int col]
        {
            get { return this.field[row, col]; }
            set { this.field[row, col] = value; }
        }

        public string this[Coordinates coordinates]
        {
            get { return this[coordinates.Row, coordinates.Col]; }
            set { this[coordinates.Row, coordinates.Col] = value; }
        }
    }
}

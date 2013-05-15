namespace BattleField
{
    using System;

    public class Field
    {
        public const string Empty = "-";
        public const string Destroyed = "X";

        private const int MaxSize = 10;

        private const int MinPercentage = 15;
        private const int MaxPercentage = 30;

        private static readonly Random random = new Random();

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
            Generate();
        }

        private void Generate()
        {
            int numberOfMines = GetRandomNumberOfMines();

            for (int currentMine = 0; currentMine < numberOfMines; currentMine++)
            {
                Coordinates currentMinePosition = GetRandomMinePosition();
                this[currentMinePosition] = ((int)GetRandomMine()).ToString();
            }
        }

        private int GetRandomNumberOfMines()
        {
            double randomPercentage = random.Next(Field.MinPercentage, Field.MaxPercentage + 1) / 100.0;

            int numberOfMines = (int)(randomPercentage * this.Rows * this.Cols);
            return numberOfMines;
        }

        private Mine GetRandomMine()
        {
            Array values = Enum.GetValues(typeof(Mine));
            int randomIndex = random.Next(values.Length);

            Mine randomMine = (Mine)values.GetValue(randomIndex);
            return randomMine;
        }

        private Coordinates GetRandomMinePosition()
        {
            Coordinates currentMine;

            do
            {
                currentMine = new Coordinates(random.Next(this.Rows), random.Next(this.Cols));
            } while (this[currentMine] != Field.Empty);

            return currentMine;
        }

        public void Destroy(Coordinates coordinates)
        {
            this[coordinates] = Field.Destroyed;
        }

        public void ForEach(Action<Coordinates> action)
        {
            ForEach(Coordinates.MinValue, Coordinates.MaxValue, action);
        }

        public void ForEach(Coordinates topLeft, Coordinates bottomRight, Action<Coordinates> action)
        {
            Coordinates safeTopLeft = new Coordinates(
                Math.Max(topLeft.Row, 0),
                Math.Max(topLeft.Col, 0));

            Coordinates safeBottomRight = new Coordinates(
                Math.Min(bottomRight.Row, this.Rows - 1),
                Math.Min(bottomRight.Col, this.Cols - 1));

            for (int row = safeTopLeft.Row; row <= safeBottomRight.Row; row++)
            {
                for (int col = safeTopLeft.Col; col <= safeBottomRight.Col; col++)
                {
                    action(new Coordinates(row, col));
                }
            }
        }

        public string this[int row, int col]
        {
            get { return this.field[row, col]; }
            private set { this.field[row, col] = value; }
        }

        public string this[Coordinates coordinates]
        {
            get { return this[coordinates.Row, coordinates.Col]; }
            private set { this[coordinates.Row, coordinates.Col] = value; }
        }
    }
}

namespace BattleField
{
    using System;

    class FieldGenerator
    {
        private const int MinMinePercentage = 15;
        private const int MaxMinePercentage = 30;

        private static readonly Random random = new Random();

        private readonly Field field = null;

        public FieldGenerator(Field field)
        {
            this.field = field;
        }

        public void Generate()
        {
            int numberOfMines = GenerateNumberOfMines();

            for (int currentMine = 0; currentMine < numberOfMines; currentMine++)
            {
                Coordinates currentMinePosition = GenerateMinePosition();
                this.field[currentMinePosition] = GenerateMine();
            }
        }

        private int GenerateNumberOfMines()
        {
            double randomPercentage = random.Next(FieldGenerator.MinMinePercentage, FieldGenerator.MaxMinePercentage + 1) / 100.0;

            int numberOfMines = (int)(randomPercentage * this.field.Rows * this.field.Cols);
            return numberOfMines;
        }

        private Coordinates GenerateMinePosition()
        {
            Coordinates position;

            do
            {
                position = new Coordinates(random.Next(this.field.Rows), random.Next(this.field.Cols));
            } while (this.field[position] != Field.Empty);

            return position;
        }

        private string GenerateMine()
        {
            Array values = Enum.GetValues(typeof(Mine));
            int randomIndex = random.Next(values.Length);

            string mine = ((int)values.GetValue(randomIndex)).ToString();
            return mine;
        }
    }
}

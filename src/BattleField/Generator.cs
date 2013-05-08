namespace BattleField
{
    using System;

    public partial class Program
    {
        private static void GenerateBattlefield(int size)
        {
            battleField = new string[size, size];

            ForEach(position => battleField[position.Row, position.Col] = "-");

            string[] minesArray = { "1", "2", "3", "4", "5" };
            Random random = new Random();

            int numberOfMines = (int)((random.Next(15, 31) / 100.0) * battleField.GetLength(0) * battleField.GetLength(1));

            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = random.Next(battleField.GetLength(0));
                int newCol = random.Next(battleField.GetLength(1));

                if (battleField[newRow, newCol] == "-")
                {
                    battleField[newRow, newCol] = minesArray[random.Next(minesArray.Length)];
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
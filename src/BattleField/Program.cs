namespace BattleField
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public partial class Program
    {
        private static string[,] battleField;

        public static void Main()
        {
#if DEBUG
            int n = 10;
#else
            Console.Write("Enter the size of the battle field: n = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Welcome to \"Battle Field\" game.");
            Console.WriteLine();
#endif
            GenerateBattlefield(n);

            int moveCounter = 0;
            while (!IsGameOver())
            {
                Render(battleField);

                Console.Write("Please enter coordinates: ");

                Coordinates input = new Coordinates();

                while (!TryReadInput(ref input))
                {
                    Console.WriteLine("Invalid move!");
                }

                DetonateMine(input);
                moveCounter++;
            }

            Console.WriteLine("Game over!");
            Console.WriteLine("Detonated mines {0}", moveCounter);
        }

        private static bool TryReadInput(ref Coordinates position)
        {
            string inputLine = Console.ReadLine();

            if (!Regex.IsMatch(inputLine, @"\s*(\d+)\s+(\d+)\s*"))
            {
                return false;
            }

            string[] inputStr = Regex.Split(inputLine.Trim(), @"\s+");
            int[] input = inputStr.Select(int.Parse).ToArray();

            if (battleField[input[0], input[1]] == "-" || battleField[input[0], input[1]] == "X")
            {
                return false;
            }

            position = new Coordinates(input[0], input[1]);

            return true;
        }

        private static bool IsGameOver()
        {
            foreach (string cell in battleField)
            {
                if (cell != "-" && cell != "X")
                {
                    return false;
                }
            }

            return true;
        }
    }
}

namespace BattleField
{
    using System;

    public partial class Program
    {
        private static void Render(string[,] battleField)
        {
            RenderHeader(battleField);
            RenderField(battleField);
        }

        private static void RenderHeader(string[,] battleField)
        {
            Console.Write("   ");
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                Console.Write("{0, 3}", row);
            }

            Console.WriteLine();

            Console.Write("   ");
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                Console.Write("---");
            }

            Console.WriteLine();
        }

        private static void RenderField(string[,] battleField)
        {
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                Console.Write("{0, 2}| ", row);
                for (int col = 0; col < battleField.GetLength(1); col++)
                {
                    Console.Write(" {0} ", battleField[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
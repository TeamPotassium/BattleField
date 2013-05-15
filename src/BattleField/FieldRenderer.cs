namespace BattleField
{
    using System;

    public static class FieldRenderer
    {
        public static void Render(Field field)
        {
            RenderHeader(field);
            RenderField(field);
        }

        private static void RenderHeader(Field battleField)
        {
            Console.Write("   ");
            for (int row = 0; row < battleField.Rows; row++)
            {
                Console.Write("{0, 3}", row);
            }

            Console.WriteLine();

            Console.Write("   ");
            for (int row = 0; row < battleField.Rows; row++)
            {
                Console.Write("---");
            }

            Console.WriteLine();
        }

        private static void RenderField(Field battleField)
        {
            for (int row = 0; row < battleField.Rows; row++)
            {
                Console.Write("{0, 2}| ", row);
                for (int col = 0; col < battleField.Cols; col++)
                {
                    Console.Write(" {0} ", battleField[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
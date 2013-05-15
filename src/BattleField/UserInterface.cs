using System;

namespace BattleField
{
    class UserInterface
    {
        private readonly Field field = null;

        public UserInterface(Field field)
        {
            this.field = field;
        }

        public static int ReadSize()
        {
            int size;

            Console.WriteLine("Enter the size of the battle field: ");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out size))
                {
                    Console.WriteLine("Wrong format.");
                }

                else if (!(0 < size && size < Field.MaxSize))
                {
                    Console.WriteLine("Size must be between {0} and {1}", 0, Field.MaxSize);
                }

                else
                {
                    break; // Valid input
                }
            }

            return size;
        }

        public Coordinates ReadCoordinates()
        {
            Console.Write("Please enter coordinates: ");

            Coordinates input;

            while (true)
            {
                if (!Coordinates.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Wrong format.");
                }

                else if (!(0 < input.Row && input.Row < this.field.Rows &&
                    0 < input.Col && input.Col < this.field.Cols))
                {
                    Console.WriteLine("Wrong coordinates.");
                }

                else if (!field.IsMine(input))
                {
                    Console.WriteLine("No mine at the given position.");
                }

                else
                {
                    break; // Valid input
                }
            }

            return input;
        }
    }
}

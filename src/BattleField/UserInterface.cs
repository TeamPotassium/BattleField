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

        public Coordinates ReadCoordinates()
        {
            Console.Write("Please enter coordinates: ");

            Coordinates input;

            while (true)
            {
                if (!Coordinates.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Wrong Format.");
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

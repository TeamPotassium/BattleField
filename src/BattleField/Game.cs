namespace BattleField
{
    using System;

    public class Game
    {
        private static Field field;

        public static void Main()
        {
#if !DEBUG
            int size = 9;
#else
            int size = UserInterface.ReadSize();
#endif

            Console.WriteLine("Welcome to \"Battle Field\" game.");

            field = new Field(size, size);
            var generator = new FieldGenerator(field);
            generator.Generate();

            Engine engine = new Engine(field);

            engine.Run();

            engine.OnGameOver += (obj, numberOfMoves) =>
                Console.WriteLine("You finished in {0} moves.", numberOfMoves);
        }
    }
}

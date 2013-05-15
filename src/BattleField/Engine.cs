using System;

namespace BattleField
{
    public class Engine
    {
        private readonly Field field = null;

        private readonly Detonator detonator = null;
        private readonly Renderer renderer = null;
        private readonly UserInterface userInterface = null;

        public int NumberOfMoves { get; private set; }

        public EventHandler<int> OnGameOver = null; // Number of moves

        public Engine(Field field)
        {
            this.field = field;

            this.detonator = new Detonator(field);
            this.renderer = new Renderer(field);
            this.userInterface = new UserInterface(field);
        }

        public void Run()
        {
            while (!IsGameOver())
            {
                renderer.Render();

                Coordinates position = this.userInterface.ReadCoordinates();
                detonator.DetonateMine(position);

                this.NumberOfMoves++;
            }

            OnGameOver(this, this.NumberOfMoves);
        }

        private bool IsGameOver()
        {
            bool result = true;

            this.field.ForEach(position =>
            {
                if (this.field.IsMine(position))
                {
                    result = false;
                }
            });

            return result;
        }
    }
}

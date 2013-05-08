namespace BattleField
{
    using System;

    public partial class Program
    {
        private static void ForEach(Coordinates topLeft, Coordinates bottomRight, Action<Coordinates> action)
        {
            Coordinates first = new Coordinates(
                Math.Max(topLeft.Row, 0),
                Math.Max(topLeft.Col, 0));

            Coordinates last = new Coordinates(
                Math.Min(bottomRight.Row, battleField.GetUpperBound(0)),
                Math.Min(bottomRight.Col, battleField.GetUpperBound(1)));

            for (int row = first.Row; row <= last.Row; row++)
            {
                for (int col = first.Col; col <= last.Col; col++)
                {
                    action(new Coordinates(row, col));
                }
            }
        }

        private static void ForEach(Action<Coordinates> action)
        {
            Coordinates topLeft = new Coordinates(0, 0);
            Coordinates bottomRight = new Coordinates(battleField.GetUpperBound(0), battleField.GetUpperBound(1));

            ForEach(topLeft, bottomRight, action);
        }
    }
}
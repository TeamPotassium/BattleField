namespace BattleField
{
    using System;
    using System.Collections.Generic;

    public partial class Program
    {
        private const char DetonatedChar = 'X';

        private static Dictionary<int, string[]> detonationAreaOfMine = new Dictionary<int, string[]>()
        {
            {
                1,
                new string[]
                {
                    "X_X",
                    "_X_",
                    "X_X"
                }
            },
            {
                2,
                new string[]
                {
                    "XXX",
                    "XXX",
                    "XXX"
                }
            },
            {
                3,
                new string[]
                {
                    "__X__",
                    "_XXX_",
                    "XXXXX",
                    "_XXX_",
                    "__X__"
                }
            },
            {
                4,
                new string[]
                {
                    "_XXX_",
                    "XXXXX",
                    "XXXXX",
                    "XXXXX",
                    "_XXX_"
                }
            },
            {
                5,
                new string[]
                {
                    "XXXXX",
                    "XXXXX",
                    "XXXXX",
                    "XXXXX",
                    "XXXXX"
                }
            }
        };

        private static void DetonateMine(Coordinates position)
        {
            string[] area = GetDetonationArea(position);

            Coordinates center = new Coordinates(area.GetLength(0) / 2, area[0].Length / 2);
            Coordinates topLeft = position - center;
            Coordinates bottomRight = position + center;

            ForEach(
                topLeft,
                bottomRight,
                p =>
                {
                    Coordinates areaPosition = p - topLeft;

                    if (area[areaPosition.Row][areaPosition.Col] == DetonatedChar)
                    {
                        battleField[p.Row, p.Col] = DetonatedChar.ToString();
                    }
                });
        }

        private static string[] GetDetonationArea(Coordinates position)
        {
            int sizeOfDetonatedMine = int.Parse(battleField[position.Row, position.Col]);
            string[] area = detonationAreaOfMine[sizeOfDetonatedMine];
            return area;
        }
    }
}

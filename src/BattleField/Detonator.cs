namespace BattleField
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Detonator
    {
        private const char Empty = '_';
        private const char Detonated = 'X';

        private static readonly Dictionary<Mine, string[]> detonationAreaOfMine = new Dictionary<Mine, string[]>()
        {
            {
                    Mine.One,
                    new string[]
                    {
                        "X_X",
                        "_X_",
                        "X_X"
                    }
            },
            {
                    Mine.Two,
                    new string[]
                    {
                        "XXX",
                        "XXX",
                        "XXX"
                    }
            },
            {
                    Mine.Three,
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
                    Mine.Four,
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
                    Mine.Five,
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

        private readonly Field field = null;

        public Detonator(Field field)
        {
            this.field = field;
        }

        public void DetonateMine(Coordinates position)
        {
            Mine mine = this.field.GetMine(position);
            string[] area = detonationAreaOfMine[mine];

            Coordinates center = new Coordinates(area.GetLength(0) / 2, area[0].Length / 2);

            Coordinates topLeft = position - center;
            Coordinates bottomRight = position + center;

            this.field.ForEach(
                topLeft,
                bottomRight,
                currentPosition =>
                {
                    Coordinates areaPosition = currentPosition - topLeft;

                    if (area[areaPosition.Row][areaPosition.Col] != Detonator.Empty)
                    {
                        this.field.Destroy(currentPosition);
                    }
                });
        }
    }
}

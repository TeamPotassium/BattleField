namespace BattleField.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GameTest1()
        {
            Console.SetIn(new StringReader(
@"9
-1 -1
1000 1000
0 0"));

            int expected = 1;

            int size = UserInterface.ReadSize();

            Field field = new Field(size, size);
            field[0, 0] = "1";

            Engine engine = new Engine(field);

            engine.OnGameOver += (obj, numberOfMoves) =>
            {
                Assert.AreEqual(Field.Detonated, field[0, 0]);
                Assert.AreEqual(Field.Detonated, field[1, 1]);

                Assert.AreEqual(expected, numberOfMoves);
            };

            engine.Run();
        }

        [TestMethod]
        public void GameTest2()
        {
            Console.SetIn(new StringReader(
@"9
8 8"));

            int expected = 1;

            int size = UserInterface.ReadSize();

            Field field = new Field(size, size);
            field[8, 8] = "1";

            Engine engine = new Engine(field);

            engine.OnGameOver += (obj, numberOfMoves) =>
            {
                Assert.AreEqual(Field.Detonated, field[8, 8]);
                Assert.AreEqual(Field.Detonated, field[7, 7]);

                Assert.AreEqual(expected, numberOfMoves);
            };

            engine.Run();
        }

        [TestMethod]
        public void RandomGameTest()
        {
            Console.SetIn(new StringReader(
@"5
0 4
3 1"));

            int expectedMoves = 2;

            int size = UserInterface.ReadSize();

            Field field = new Field(size, size);

            FieldGenerator generator = new FieldGenerator(field, new Random(0));
            generator.Generate();

            Engine engine = new Engine(field);

            engine.OnGameOver += (obj, numberOfMoves) =>
            {
                Assert.AreEqual(expectedMoves, numberOfMoves);
            };

            engine.Run();

            string[] expectedField =
            {
                "-",  "-", "X", "X", "X",
                "X",  "X", "X", "X", "X",
                "X",  "X", "X", "X", "X",
                "X",  "X", "X", "X", "-",
                "X",  "X", "X", "X", "-"
            };


            CollectionAssert.AreEquivalent(expectedField, field.Value);
        }
    }
}

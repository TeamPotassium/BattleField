namespace BattleField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void AdditionTest()
        {
            Coordinates actual = new Coordinates(123, 456) + new Coordinates(789, 101112);

            Coordinates expected = new Coordinates(912, 101568);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            Coordinates actual = new Coordinates(123, 456) - new Coordinates(789, 101112);

            Coordinates expected = new Coordinates(-666, -100656);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void OverflowRowTest()
        {
            Coordinates coordinates = Coordinates.MaxValue + new Coordinates(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void OverflowColTest()
        {
            Coordinates coordinates = Coordinates.MaxValue + new Coordinates(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void UnderflowRowTest()
        {
            Coordinates coordinates = Coordinates.MinValue - new Coordinates(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void UnderflowColTest()
        {
            Coordinates coordinates = Coordinates.MinValue - new Coordinates(0, 1);
        }

        [TestMethod]
        public void ParseTest()
        {
            Coordinates expected = new Coordinates(123, 456);

            Coordinates actual = Coordinates.Parse("123 456");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseWithWhitespaceTest()
        {
            Coordinates expected = new Coordinates(123, 456);

            Coordinates actual = Coordinates.Parse("   123   456   ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseNullTest()
        {
            Coordinates.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseEmptyStringTest()
        {
            Coordinates.Parse(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseWithLessCoordinatesTest()
        {
            Coordinates.Parse("123");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseWithMoreCoordinatesTest()
        {
            Coordinates.Parse("123 456 789");
        }

        [TestMethod]
        public void TryParseValidTest()
        {
            Coordinates actual;
            Coordinates.TryParse("123 456", out actual);

            Coordinates expected = new Coordinates(123, 456);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParseInvalidTest()
        {
            Coordinates actual;
            Coordinates.TryParse("123 456 789", out actual);

            Coordinates expected = new Coordinates(0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string actual = new Coordinates(123, 456).ToString();

            string expected = "123 456";

            Assert.AreEqual(expected, actual);
        }
    }
}

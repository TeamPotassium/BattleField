namespace BattleField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeRowTest()
        {
            new Field(-1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeColTest()
        {
            new Field(5, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroRowTest()
        {
            new Field(0, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroColTest()
        {
            new Field(5, 0);
        }

        [TestMethod]
        public void MaxFieldTest()
        {
            new Field(Field.MaxSize, Field.MaxSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpperBoundRowTest()
        {
            new Field(Field.MaxSize + 1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpperBoundColTest()
        {
            new Field(5, Field.MaxSize + 1);
        }
    }
}

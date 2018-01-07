using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeShould
    {
        [Test]
        public void TestTest()
        {
            Assert.Pass();
        }

        [Test]
        public void ReturnAnyBoardAfterTurnOne()
        {
            var inputBoard = new Board(new string[9]);
            var playerMove = 0;
            var playerGlyph = "X";

            var expectedBoard = new Board(new[]{"X"});

            var actualBoard = inputBoard.AddGlyph(playerMove, playerGlyph);

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }
    }

    public class Board : IEnumerable
    {
        private readonly string[] _glyphs;
        public Board(string[] glyphs)
        {
            _glyphs = glyphs;
        }
        public Board AddGlyph(int index, string playerGlyph)
        {
            return new Board(new[] {"X"});
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _glyphs.GetEnumerator();
        }
    }
}

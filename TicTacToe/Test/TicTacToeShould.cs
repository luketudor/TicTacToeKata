using System.Collections;
using System.Collections.Generic;
using System.Media;
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
        public void ReturnAnyFirstMove()
        {
            var game = new TicTacToeGame();
            var board = new List<string>();
            var playerGlyph = "X";
            var playerIndex = 0;

            var expectedBoard = new List<string>(new[] {playerGlyph});

            var actualBoard = game.NextBoard(board, playerIndex, playerGlyph);

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }
    }
}

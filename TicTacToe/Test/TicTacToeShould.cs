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

            var expectedBoard = new List<string>(new[] {"X"});

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }

        [Ignore("Not implemented yet")]
        [Test]
        public void ReturnAnySecondMove()
        {
            var game = new TicTacToeGame(new List<string>(new[] {"X"}), "O");

            var expectedBoard = new List<string>(new[] {"X", "O"});

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }
    }
}

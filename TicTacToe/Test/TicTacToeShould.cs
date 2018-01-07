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
        public void ReturnAnyPlayerMoveForEmptyBoard()
        {
            var player = new Player();
            var board = new List<string>();

            var actualMove = player.TakeTurn(board);

            Assert.Less(actualMove, 10);
            Assert.GreaterOrEqual(actualMove, 0);
        }
    }

    public class Player
    {
        public int TakeTurn(List<string> board)
        {
            return 0;
        }
    }
}

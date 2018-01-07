using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class PlayerShould
    {
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
}

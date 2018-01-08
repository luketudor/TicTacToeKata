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

            var actualMove = player.TakeTurn(new List<string>());

            Assert.Less(actualMove, 10);
            Assert.GreaterOrEqual(actualMove, 0);
        }
    }
}

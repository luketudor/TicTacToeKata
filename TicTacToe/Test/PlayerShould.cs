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
            var player = new Player(PlayerGlyph.Cross);

            var actualMove = player.TakeTurn(new PlayerGlyph[0]);

            Assert.Less(actualMove, 10);
            Assert.GreaterOrEqual(actualMove, 0);
        }

        [Test]
        public void ReturnAnyPlayerMoveForSecondTurnBoard()
        {
            var player = new ComputerPlayer(PlayerGlyph.Naught);

            var actualMove = player.TakeTurn(new[] {PlayerGlyph.Cross});

            Assert.Less(actualMove, 10);
            Assert.GreaterOrEqual(actualMove, 1);
        }
    }
}

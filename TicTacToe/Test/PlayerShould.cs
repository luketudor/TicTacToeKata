using System.Linq;
using NUnit.Framework;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe.Test
{
    [TestFixture]
    public class PlayerShould
    {
        [Test]
        public void ReturnAnyPlayerMoveForEmptyBoard()
        {
            var player = new ComputerPlayer(PlayerGlyph.Cross);
            var board = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();

            var actualMove = player.TakeTurn(board);

            Assert.Less(actualMove, 10);
            Assert.GreaterOrEqual(actualMove, 0);
        }

        [Test]
        public void ReturnAnyPlayerMoveForSecondTurnBoard()
        {
            var player = new ComputerPlayer(PlayerGlyph.Naught);
            var board = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();
            board[0] = PlayerGlyph.Cross;

            var actualMove = player.TakeTurn(board);

            Assert.Less(actualMove, 10);
            Assert.GreaterOrEqual(actualMove, 1);
        }
    }
}

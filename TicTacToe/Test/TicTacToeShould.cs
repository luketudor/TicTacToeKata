using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeShould
    { 
        [Test]
        public void ReturnAnyFirstMove()
        {
            var game = new TicTacToeGame(new ComputerPlayer(PlayerGlyph.Cross), new ComputerPlayer(PlayerGlyph.Naught));

            var expectedBoard = new[] {PlayerGlyph.Cross};

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnAnySecondMove()
        {
            var game = new TicTacToeGame(
                new ComputerPlayer(PlayerGlyph.Cross),
                new ComputerPlayer(PlayerGlyph.Naught),
                new[] { PlayerGlyph.Cross },
                false);

            var expectedBoard = new[] {PlayerGlyph.Cross, PlayerGlyph.Naught};

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnFirstTwoMoves()
        {
            var game = new TicTacToeGame(
                new ComputerPlayer(PlayerGlyph.Cross),
                new ComputerPlayer(PlayerGlyph.Naught));

            var expectedBoard = new[] { PlayerGlyph.Cross, PlayerGlyph.Naught };

            game.NextBoard();
            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }
    }
}

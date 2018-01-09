using System.Linq;
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

            CollectionAssert.IsSubsetOf(expectedBoard, actualBoard);
            Assert.AreEqual(9, actualBoard.Length);
        }

        [Ignore("Constructor may be removed in the future")]
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

            CollectionAssert.IsSubsetOf(expectedBoard, actualBoard);
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

            CollectionAssert.IsSubsetOf(expectedBoard, actualBoard);
            Assert.AreEqual(9, actualBoard.Length);
        }

        [Test]
        public void ReturnNoWinnerDeclarationOnFirstMove()
        {
            var game = new TicTacToeGame(
                new ComputerPlayer(PlayerGlyph.Cross),
                new ComputerPlayer(PlayerGlyph.Naught));

            game.NextBoard();

            Assert.Null(game.Winner());
        }

        [Test]
        public void ReturnPlayerOneAsWinner()
        {
            var player1 = new ComputerPlayer(PlayerGlyph.Cross);
            var board = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();
            board[0] = PlayerGlyph.Cross;
            board[1] = PlayerGlyph.Cross;
            board[2] = PlayerGlyph.Cross;

            var game = new TicTacToeGame(
                player1,
                new ComputerPlayer(PlayerGlyph.Naught),
                board,
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnPlayerOneAsWinnerWithColumns()
        {
            var player1 = new ComputerPlayer(PlayerGlyph.Cross);
            var board = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();
            board[0] = PlayerGlyph.Cross;
            board[3] = PlayerGlyph.Cross;
            board[6] = PlayerGlyph.Cross;

            var game = new TicTacToeGame(
                player1,
                new ComputerPlayer(PlayerGlyph.Naught),
                board,
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnPlayerOneAsWinnerWithDiagonal()
        {
            var player1 = new ComputerPlayer(PlayerGlyph.Cross);
            var board = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();
            board[0] = PlayerGlyph.Cross;
            board[4] = PlayerGlyph.Cross;
            board[8] = PlayerGlyph.Cross;

            var game = new TicTacToeGame(
                player1,
                new ComputerPlayer(PlayerGlyph.Naught),
                board,
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnPlayerTwoAsWinnerWithDiagonal()
        {
            var player1 = new ComputerPlayer(PlayerGlyph.Cross);
            var board = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();
            board[2] = PlayerGlyph.Cross;
            board[4] = PlayerGlyph.Cross;
            board[6] = PlayerGlyph.Cross;

            var game = new TicTacToeGame(
                player1,
                new ComputerPlayer(PlayerGlyph.Naught),
                board,
                true);

            Assert.AreEqual(player1, game.Winner());
        }
    }
}

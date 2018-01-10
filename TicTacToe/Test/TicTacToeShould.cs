using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeShould
    {
        private const PlayerGlyph X = PlayerGlyph.Cross;
        private const PlayerGlyph O = PlayerGlyph.Naught;
        private const PlayerGlyph _ = PlayerGlyph.Empty;

        [Test]
        public void ReturnAnyFirstMove()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross, 0),
                new DummyPlayer());

            var expectedBoard = new[]
            {
                X, _, _,
                _, _, _,
                _, _, _
            };

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnAnySecondMove()
        {
            var game = new TicTacToeGame(
                new DummyPlayer(),
                new StubPlayer(PlayerGlyph.Naught, 1),
                new[]
                {
                    X, _, _,
                    _, _, _,
                    _, _, _
                },
                false);

            var expectedBoard = new[]
            {
                X, O, _,
                _, _, _,
                _, _, _
            };

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnFirstTwoMoves()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross, 0),
                new StubPlayer(PlayerGlyph.Naught, 1));

            var expectedBoard = new[]
            {
                X, O, _,
                _, _, _,
                _, _, _
            };

            game.NextBoard();
            var actualBoard = game.NextBoard();

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnNoWinnerDeclarationOnNoMoves()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
                new StubPlayer(PlayerGlyph.Naught));

            Assert.Null(game.Winner());
        }

        [Test]
        public void ReturnPlayerOneAsWinner()
        {
            var player1 = new StubPlayer(PlayerGlyph.Cross);

            var game = new TicTacToeGame(
                player1,
                new StubPlayer(PlayerGlyph.Naught),
                new[]
                {
                    X, X, X,
                    _, _, _,
                    _, _, _
                },
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnPlayerOneAsWinnerWithColumns()
        {
            var player1 = new StubPlayer(PlayerGlyph.Cross);

            var game = new TicTacToeGame(
                player1,
                new StubPlayer(PlayerGlyph.Naught),
                new[]
                {
                    X, _, _,
                    X, _, _,
                    X, _, _
                },
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnPlayerOneAsWinnerWithDiagonal()
        {
            var player1 = new StubPlayer(PlayerGlyph.Cross);

            var game = new TicTacToeGame(
                player1,
                new StubPlayer(PlayerGlyph.Naught),
                new[]
                {
                    X, _, _,
                    _, X, _,
                    _, _, X
                },
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnPlayerTwoAsWinnerWithDiagonal()
        {
            var player1 = new StubPlayer(PlayerGlyph.Cross);

            var game = new TicTacToeGame(
                player1,
                new StubPlayer(PlayerGlyph.Naught),
                new[]
                {
                    _, _, X,
                    _, X, _,
                    X, _, _
                },
                true);

            Assert.AreEqual(player1, game.Winner());
        }

        [Test]
        public void ReturnNoDrawDeclarationOnFirstMove()
        {
            var game = new TicTacToeGame(
                new DummyPlayer(), 
                new DummyPlayer());

            Assert.AreEqual(false, game.IsDraw());
        }

        [Test]
        public void ReturnDrawDeclarationOnFullBoard()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
                new StubPlayer(PlayerGlyph.Naught),
                new[]
                {
                    X, O, O,
                    O, X, X,
                    X, O, O
                },
                true);

            Assert.AreEqual(true, game.IsDraw());
        }
    }
}
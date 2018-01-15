using NUnit.Framework;
using TicTacToe.Enums;
using TicTacToe.Players;
using TicTacToe.Test.Stubs;

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
                new StubPlayer(PlayerGlyph.Naught));

            var expectedBoard = new[]
            {
                X, _, _,
                _, _, _,
                _, _, _
            };

            game.NextTurn();
            var actualBoard = game.GetBoard();

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnAnySecondMove()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
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

            game.NextTurn();
            var actualBoard = game.GetBoard();

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

            game.NextTurn();
            game.NextTurn();
            var actualBoard = game.GetBoard();

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }

        [Test]
        public void ReturnNoWinnerDeclarationOnNoMoves()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
                new StubPlayer(PlayerGlyph.Naught));

            game.IsWinner(out var winner);

            Assert.Null(winner);
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

            game.IsWinner(out var winner);

            Assert.AreEqual(player1, winner);
        }

        [Test]
        public void ReturnNoDrawDeclarationOnFirstMove()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
                new StubPlayer(PlayerGlyph.Naught));

            Assert.False(game.IsDraw());
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

            Assert.True(game.IsDraw());
        }

        [Test]
        public void ShouldCallOnDrawEvent()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
                new StubPlayer(PlayerGlyph.Naught, 8),
                new[]
                {
                    X, O, O,
                    O, X, X,
                    X, O, _
                },
                false);

            var drawEventCalled = false;

            game.RaiseDrawEvent += (sender, eventArgs) => drawEventCalled = true;

            game.Run();

            Assert.True(drawEventCalled);
        }

        [Test]
        public void ShouldCallOnWinEvent()
        {
            var player1 = new StubPlayer(PlayerGlyph.Cross, 8);
            var player2 = new StubPlayer(PlayerGlyph.Naught);

            var game = new TicTacToeGame(
                player1,
                player2,
                new[]
                {
                    X, O, O,
                    O, X, X,
                    X, O, _
                },
                true);

            AbstractPlayer winningPlayer = null;

            game.RaiseWinEvent += (sender, winner) => winningPlayer = winner;

            game.Run();

            Assert.AreEqual(player1, winningPlayer);
        }

        [Test]
        public void ShouldCallOnRenderEvent()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross),
                new StubPlayer(PlayerGlyph.Naught, 8),
                new[]
                {
                    X, O, O,
                    O, X, X,
                    X, O, _
                },
                false);

            var expectedBoard = new[]
            {
                X, O, O,
                O, X, X,
                X, O, O
            };

            PlayerGlyph[] actualBoard = null;

            game.RaiseRenderEvent += (sender, board) => actualBoard = board;

            game.Run();

            CollectionAssert.AreEqual(expectedBoard, actualBoard);
        }
    }
}
using System;
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
                new DummyPlayer());

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

        [Ignore("Exception removed")]
        [Test]
        public void ThrowArgumentExeceptionOnAttemptedOverwrite()
        {
            var game = new TicTacToeGame(
                new StubPlayer(PlayerGlyph.Cross, 0),
                new DummyPlayer(),
                new[]
                {
                    O, _, _,
                    _, _, _,
                    _, _, _
                },
                true);

            Assert.Catch<ArgumentException>(game.NextTurn, "Position is not empty");
        }
    }
}
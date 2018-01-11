using System;
using System.IO;
using NUnit.Framework;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TextStreamPlayerShould
    {
        private const PlayerGlyph O = PlayerGlyph.Naught;
        private const PlayerGlyph _ = PlayerGlyph.Empty;

        [Test]
        public void ReturnAnIntegerHumanMove()
        {
            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, new StringReader("0"), Console.Out);

            Assert.AreEqual(0, player.MakeMove(board));
        }

        [Test]
        public void ReturnTwoIntegerHumanMoves()
        {
            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, new StringReader("0\n1"), Console.Out);

            Assert.AreEqual(0, player.MakeMove(board));
            Assert.AreEqual(1, player.MakeMove(board));
        }

        [Test]
        public void WriteErrorMessageForAttempedOverwrite()
        {
            var stringWriter = new StringWriter();

            var board = new[]
            {
                O, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, new StringReader("0\n1"), stringWriter);
            player.MakeMove(board);

            Assert.AreEqual($"That position is occupied, please try again{stringWriter.NewLine}", stringWriter.ToString());
        }

        [Test]
        public void WriteErrorMessageForAttempedOutOfBounds()
        {
            var stringWriter = new StringWriter();

            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, new StringReader("9\n1"), stringWriter);
            player.MakeMove(board);

            Assert.AreEqual($"That index is out of bounds, please try again{stringWriter.NewLine}", stringWriter.ToString());
        }

        [Test]
        public void WriteErrorMessageForAttempedNegativePosition()
        {
            var stringWriter = new StringWriter();

            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, new StringReader("-1\n1"), stringWriter);
            player.MakeMove(board);

            Assert.AreEqual($"Negative indices are not allowed, please try again{stringWriter.NewLine}", stringWriter.ToString());
        }

        [Test]
        public void WriteErrorMessageForInvalidFormat()
        {
            var stringWriter = new StringWriter();

            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, new StringReader("2.0\n1"), stringWriter);
            player.MakeMove(board);

            Assert.AreEqual($"Invalid format: Positive integers only, please try again{stringWriter.NewLine}", stringWriter.ToString());
        }
    }
}
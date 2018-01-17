using System;
using System.IO;
using NUnit.Framework;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TextPlayerShould
    {
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

            var player = new TextPlayer(PlayerGlyph.Cross, new StringReader("0"), Console.Out);

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

            var player = new TextPlayer(PlayerGlyph.Cross, new StringReader("0\n1"), Console.Out);

            Assert.AreEqual(0, player.MakeMove(board));
            Assert.AreEqual(1, player.MakeMove(board));
        }
    }
}
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
        private const PlayerGlyph _ = PlayerGlyph.Empty;

        [Test]
        public void ReturnAnIntegerHumanMove()
        {
            Console.SetIn(new StringReader("0"));

            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, Console.In, Console.Out);

            Assert.AreEqual(0, player.MakeMove(board));
        }

        [Test]
        public void ReturnTwoIntegerHumanMoves()
        {
            Console.SetIn(new StringReader("0\n1"));

            var board = new[]
            {
                _, _, _,
                _, _, _,
                _, _, _
            };

            var player = new TextStreamPlayer(PlayerGlyph.Cross, Console.In, Console.Out);

            Assert.AreEqual(0, player.MakeMove(board));
            Assert.AreEqual(1, player.MakeMove(board));
        }
    }
}
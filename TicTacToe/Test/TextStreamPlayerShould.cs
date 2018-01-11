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
        [Ignore("Broken test")]
        [Test]
        public void ReturnAnIntegerHumanMove()
        {
            Console.SetIn(new StringReader("0"));

            var player = new TextStreamPlayer(PlayerGlyph.Cross, Console.In, Console.Out);

            Assert.AreEqual(0, player.MakeMove(new PlayerGlyph[0]));
        }

        [Ignore("Broken test")]
        [Test]
        public void ReturnTwoIntegerHumanMoves()
        {
            Console.SetIn(new StringReader("0\n1"));

            var player = new TextStreamPlayer(PlayerGlyph.Cross, Console.In, Console.Out);

            Assert.AreEqual(0, player.MakeMove(new PlayerGlyph[0]));
            Assert.AreEqual(1, player.MakeMove(new PlayerGlyph[0]));
        }
    }
}
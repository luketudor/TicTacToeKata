﻿using System.Collections;
using System.Collections.Generic;
using System.Media;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeShould
    {
        [Test]
        public void TestTest()
        {
            Assert.Pass();
        }

        [Test]
        public void ReturnAnyFirstMove()
        {
            var game = new TicTacToeGame();

            var expectedBoard = new List<PlayerGlyph>(new[] {PlayerGlyph.Cross});

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }

        [Ignore("Not implemented yet")]
        [Test]
        public void ReturnAnySecondMove()
        {
            var game = new TicTacToeGame(new List<PlayerGlyph>(new[] {PlayerGlyph.Cross}),
                new Player(PlayerGlyph.Naught));

            var expectedBoard = new List<PlayerGlyph>(new[] {PlayerGlyph.Cross, PlayerGlyph.Naught});

            var actualBoard = game.NextBoard();

            CollectionAssert.AreEquivalent(expectedBoard, actualBoard);
        }
    }
}

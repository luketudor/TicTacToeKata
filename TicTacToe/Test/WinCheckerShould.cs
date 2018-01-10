using NUnit.Framework;
using TicTacToe.Enums;

namespace TicTacToe.Test
{
    [TestFixture]
    public class WinCheckerShould
    {
        private const PlayerGlyph X = PlayerGlyph.Cross;
        private const PlayerGlyph O = PlayerGlyph.Naught;
        private const PlayerGlyph _ = PlayerGlyph.Empty;

        [Test]
        public void ReturnCrossPlayerAsWinnerWithColumns()
        {
            var winChecker = new WinChecker();

            Assert.IsTrue(winChecker.HasPlayerWon(
                new[]
                {
                    X, _, _,
                    X, _, _,
                    X, _, _
                },
                PlayerGlyph.Cross));
        }

        [Test]
        public void ReturnCrossPlayerAsWinnerWithDiagonal()
        {
            var winChecker = new WinChecker();

            Assert.IsTrue(winChecker.HasPlayerWon(
                new[]
                {
                    X, _, _,
                    _, X, _,
                    _, _, X
                },
                PlayerGlyph.Cross));
        }

        [Test]
        public void ReturnNaughtPlayerAsWinnerWithDiagonal()
        {
            var winChecker = new WinChecker();

            Assert.IsTrue(winChecker.HasPlayerWon(
                new[]
                {
                    _, _, O,
                    _, O, _,
                    O, _, _
                },
                PlayerGlyph.Naught));
        }
    }
}
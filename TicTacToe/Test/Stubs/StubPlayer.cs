using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe.Test.Stubs
{
    public class StubPlayer : AbstractPlayer
    {
        private readonly int _whereToMove;

        public StubPlayer(PlayerGlyph glyph) : this(glyph, -1)
        {
        }

        public StubPlayer(PlayerGlyph glyph, int whereToMove)
        {
            this.glyph = glyph;
            _whereToMove = whereToMove;
        }

        public override int MakeMove(PlayerGlyph[] board)
        {
            return _whereToMove;
        }
    }
}
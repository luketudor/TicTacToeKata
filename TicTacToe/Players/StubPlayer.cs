using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class StubPlayer : IPlayer
    {
        private readonly PlayerGlyph _glyph;
        private readonly int _whereToMove;

        public StubPlayer(PlayerGlyph glyph) : this(glyph, -1)
        {
        }

        public StubPlayer(PlayerGlyph glyph, int whereToMove)
        {
            _glyph = glyph;
            _whereToMove = whereToMove;
        }

        public PlayerGlyph GetGlyph()
        {
            return _glyph;
        }

        public int TakeTurn(PlayerGlyph[] board)
        {
            return _whereToMove;
        }
    }
}
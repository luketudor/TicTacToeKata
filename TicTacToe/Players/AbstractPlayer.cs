using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public abstract class AbstractPlayer
    {
        protected PlayerGlyph glyph;
        public PlayerGlyph GetGlyph() => glyph;
        public abstract int MakeMove(PlayerGlyph[] board);
    }
}
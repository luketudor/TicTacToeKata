using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public abstract class AbstractPlayer
    {
        protected PlayerGlyph Glyph;

        public PlayerGlyph GetGlyph()
        {
            return Glyph;
        }

        public abstract int MakeMove(PlayerGlyph[] board);
    }
}
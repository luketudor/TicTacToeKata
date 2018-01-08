using System.Collections.Generic;

namespace TicTacToe
{
    public class Player
    {
        public PlayerGlyph Glyph { get; }

        public Player(PlayerGlyph glyph)
        {
            Glyph = glyph;
        }

        public virtual int TakeTurn(IReadOnlyList<PlayerGlyph> board)
        {
            return 0;
        }
    }
}
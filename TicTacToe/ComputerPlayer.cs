using System.Collections.Generic;

namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        private readonly PlayerGlyph _glyph;
        public ComputerPlayer(PlayerGlyph glyph)
        {
           _glyph = glyph;
        }

        public PlayerGlyph GetGlyph()
        {
            return _glyph;
        }

        public int TakeTurn(IReadOnlyList<PlayerGlyph> board)
        {
            return board.Count;
        }
    }
}

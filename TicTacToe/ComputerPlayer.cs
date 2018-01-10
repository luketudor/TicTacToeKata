using System;

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

        public int TakeTurn(PlayerGlyph[] board)
        {
            for (var i = 0; i < board.Length; i++)
            {
                if (board[i] == PlayerGlyph.Empty)
                {
                    return i;
                }
            }
            throw new ArgumentException();
        }
    }
}

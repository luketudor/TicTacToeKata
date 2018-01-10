using System;

namespace TicTacToe
{
    public class DummyPlayer : IPlayer
    {
        public PlayerGlyph GetGlyph()
        {
            throw new NotSupportedException();
        }

        public int TakeTurn(PlayerGlyph[] board)
        {
            throw new NotSupportedException();
        }
    }
}

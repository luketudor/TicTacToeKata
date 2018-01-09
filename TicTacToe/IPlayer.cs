using System.Collections.Generic;

namespace TicTacToe
{
    public interface IPlayer
    {
        PlayerGlyph GetGlyph();
        int TakeTurn(PlayerGlyph[] board);
    }
}
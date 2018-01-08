using System.Collections.Generic;

namespace TicTacToe
{
    public interface IPlayer
    {
        PlayerGlyph GetGlyph();
        int TakeTurn(IReadOnlyList<PlayerGlyph> board);
    }
}
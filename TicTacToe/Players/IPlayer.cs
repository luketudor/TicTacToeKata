using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        PlayerGlyph GetGlyph();
        int TakeTurn(PlayerGlyph[] board);
    }
}
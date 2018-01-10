using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        PlayerGlyph GetGlyph();
        int MakeMove(PlayerGlyph[] board);
    }
}
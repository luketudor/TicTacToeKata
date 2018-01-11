using TicTacToe.Enums;

namespace TicTacToe
{
    public interface IBoardRenderer
    {
        void Render(PlayerGlyph[] board);
    }
}
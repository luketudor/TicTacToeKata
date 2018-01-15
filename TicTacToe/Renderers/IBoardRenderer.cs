using TicTacToe.Enums;

namespace TicTacToe.Renderers
{
    public interface IBoardRenderer
    {
        void Render(PlayerGlyph[] board);
    }
}
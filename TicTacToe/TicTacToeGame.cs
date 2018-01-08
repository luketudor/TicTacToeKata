using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public List<string> NextBoard(IReadOnlyList<string> board, int index, string playerGlyph)
        {
            return new List<string>(new[] {playerGlyph});
        }
    }
}

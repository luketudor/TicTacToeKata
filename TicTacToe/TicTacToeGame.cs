using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame()
        {
        }

        internal TicTacToeGame(IReadOnlyList<PlayerGlyph> previousBoard, PlayerGlyph currentPlayer)
        {
            
        }

        public IReadOnlyList<PlayerGlyph> NextBoard()
        {
            return new List<PlayerGlyph>(new[] {PlayerGlyph.Cross});
        }
    }
}

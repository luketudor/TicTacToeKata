using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private IReadOnlyList<PlayerGlyph> _currentBoard;
        private Player _currentPlayer;

        public TicTacToeGame() : this(new List<PlayerGlyph>(), new Player(PlayerGlyph.Cross))
        {
        }

        internal TicTacToeGame(IReadOnlyList<PlayerGlyph> currentBoard, Player currentPlayer)
        {
            _currentBoard = currentBoard;
            _currentPlayer = currentPlayer;
        }

        public IReadOnlyList<PlayerGlyph> NextBoard()
        {
            var list = new List<PlayerGlyph>(_currentBoard);
            list.Insert(_currentPlayer.TakeTurn(_currentBoard), _currentPlayer.Glyph);
            return list;
        }
    }
}

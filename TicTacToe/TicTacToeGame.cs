using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private IReadOnlyList<PlayerGlyph> _currentBoard;
        private ComputerPlayer _currentPlayer;

        public TicTacToeGame() : this(new List<PlayerGlyph>(), new ComputerPlayer(PlayerGlyph.Cross))
        {
        }

        internal TicTacToeGame(IReadOnlyList<PlayerGlyph> currentBoard, ComputerPlayer currentPlayer)
        {
            _currentBoard = currentBoard;
            _currentPlayer = currentPlayer;
        }

        public IReadOnlyList<PlayerGlyph> NextBoard()
        {
            var list = new List<PlayerGlyph>(_currentBoard);
            list.Insert(_currentPlayer.TakeTurn(_currentBoard), _currentPlayer.GetGlyph());
            return list;
        }
    }
}

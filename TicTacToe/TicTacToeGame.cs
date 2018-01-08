using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private IReadOnlyList<PlayerGlyph> _currentBoard;
        private IPlayer _currentPlayer;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public TicTacToeGame(IPlayer player1, IPlayer player2) : this(player1, player2, new List<PlayerGlyph>(), player1)
        {
        }

        internal TicTacToeGame(IPlayer player1, IPlayer player2, IReadOnlyList<PlayerGlyph> currentBoard, IPlayer currentPlayer)
        {
            _currentBoard = currentBoard;
            _currentPlayer = currentPlayer;
            _player1 = player1;
            _player2 = player2;
        }

        public IReadOnlyList<PlayerGlyph> NextBoard()
        {
            var list = new List<PlayerGlyph>(_currentBoard);
            list.Insert(_currentPlayer.TakeTurn(_currentBoard), _currentPlayer.GetGlyph());
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
            _currentBoard = list;
            return _currentBoard;
        }
    }
}

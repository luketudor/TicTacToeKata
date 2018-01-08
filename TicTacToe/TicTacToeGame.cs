using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private IReadOnlyList<PlayerGlyph> _currentBoard;
        private bool _player1Turn;

        public TicTacToeGame(IPlayer player1, IPlayer player2) : this(player1, player2, new List<PlayerGlyph>(), true)
        {
        }

        internal TicTacToeGame(IPlayer player1, IPlayer player2, IReadOnlyList<PlayerGlyph> currentBoard, bool player1Turn)
        {
            _player1 = player1;
            _player2 = player2;
            _currentBoard = currentBoard;
            _player1Turn = player1Turn;
        }

        public IReadOnlyList<PlayerGlyph> NextBoard()
        {
            var list = new List<PlayerGlyph>(_currentBoard);
            var currentPlayer = _player1Turn ? _player1 : _player2;
            list.Insert(currentPlayer.TakeTurn(_currentBoard), currentPlayer.GetGlyph());
            _player1Turn = !_player1Turn;
            _currentBoard = list;
            return _currentBoard;
        }
    }
}
